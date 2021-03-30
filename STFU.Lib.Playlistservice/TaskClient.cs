using System;
using System.Linq;
using System.Net;
using System.Text;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Playlistservice.Model;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Playlistservice
{
	public class TaskClient : AbstractClient
	{
		private static readonly ILog LOGGER = LogManager.GetLogger(nameof(TaskClient));

		public TaskClient(Uri host) : base(host) { }
		public TaskClient(Uri host, string user, string pass) : base(host, user, pass) { }

		public Task[] GetTasks(long accountId, long[] ids, DateTime? after, DateTime? before, int? attemptCount, int? minAttemptCount, int? maxAttemptCount,
			string playlistId, string playlistTitle, string videoId, string videoTitle, TaskState[] states, TaskOrder? order, TaskOrderDirection? direction)
		{
			LOGGER.Info($"Getting a list of tasks for accountId: {accountId}");
			LOGGER.Info($"Selected filters: after: {after}, before: {before}, ids: {(ids != null ? JsonConvert.SerializeObject(ids) : null)}, " +
				$"attemptCount: {attemptCount}, minAttemptCount: {minAttemptCount}, maxAttemptCount: {maxAttemptCount}, " +
				$"playlistId: {playlistId}, playlistTitle: {playlistTitle}, videoId: {videoId}, videoTitle: {videoTitle}, " +
				$"states: {states}, order: {order}, direction: {direction}");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, CreateUriPath($"/accounts/{accountId}/tasks", ids, after, before, attemptCount,
				minAttemptCount, maxAttemptCount, playlistId, playlistTitle, videoId, videoTitle, states, order, direction)));
			request.Method = "GET";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			string json = WebService.Communicate(request);

			LOGGER.Info($"Got a result, returning task");
			return JsonConvert.DeserializeObject<Task[]>(json)?.Select(t => GetTaskWithLocalTime(t)).ToArray();
		}

		private Task GetTaskWithLocalTime(Task task)
		{
			task.addAt = task.addAt.ToLocalTime();
			return task;
		}

		public Task CreateTask(long accountId, Task task)
		{
			LOGGER.Info($"Creating a new task for accountId: {accountId}");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts/{accountId}/tasks"));
			request.Method = "POST";
			request.Accept = "application/json";
			request.ContentType = "application/json";

			task.addAt = task.addAt.ToUniversalTime();

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(task));
			string json = WebService.Communicate(request, bytes);

			LOGGER.Info($"Got a result, returning task");
			return JsonConvert.DeserializeObject<Task>(json);
		}

		public Task UpdateTask(long accountId, Task task)
		{
			LOGGER.Info($"Updating task with id: {task.id} for accountId: {accountId}");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts/{accountId}/tasks/{task.id}"));
			request.Method = "PUT";
			request.Accept = "application/json";
			request.ContentType = "application/json";

			task.addAt = task.addAt.ToUniversalTime();

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(task));
			string json = WebService.Communicate(request, bytes);

			LOGGER.Info($"Got a result, returning task");
			return JsonConvert.DeserializeObject<Task>(json);
		}

		public bool DeleteTask(long accountId, long taskId)
		{
			LOGGER.Info($"Deleting task with id: {taskId} for accountId: {accountId}");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Host, $"/accounts/{accountId}/tasks/{taskId}"));
			request.Method = "DELETE";
			request.Accept = "application/json";

			if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
			{
				Utils.AddBasicAuth(request, Username, Password);
			}

			string json = WebService.Communicate(request);

			LOGGER.Info($"Deletion was successful: {!json.ToLower().Contains("error")}");

			return !json.ToLower().Contains("error");
		}

		private string CreateUriPath(string basePath, long[] ids, DateTime? after, DateTime? before, int? attemptCount, int? minAttemptCount, int? maxAttemptCount,
			string playlistId, string playlistTitle, string videoId, string videoTitle, TaskState[] states, TaskOrder? order, TaskOrderDirection? direction)
		{
			basePath = $"{basePath}?";

			if (ids != null)
			{
				foreach (var id in ids)
				{
					basePath = $"{basePath}id={id}&";
				}
			}

			if (after != null)
			{
				basePath = $"{basePath}addAtAfter={after.Value.ToString("yyyy-MM-ddTHH\\:mm")}&";
			}

			if (before != null)
			{
				basePath = $"{basePath}addAtBefore={before.Value.ToString("yyyy-MM-ddTHH\\:mm")}&";
			}

			if (attemptCount != null)
			{
				basePath = $"{basePath}attemptCount={attemptCount.Value}&";
			}

			if (minAttemptCount != null)
			{
				basePath = $"{basePath}minAttemptCount={minAttemptCount.Value}&";
			}

			if (maxAttemptCount != null)
			{
				basePath = $"{basePath}maxAttemptCount={maxAttemptCount.Value}&";
			}

			if (!string.IsNullOrWhiteSpace(playlistId))
			{
				basePath = $"{basePath}playlistId={playlistId}&";
			}

			if (!string.IsNullOrWhiteSpace(playlistTitle))
			{
				basePath = $"{basePath}playlistTitle={playlistTitle}&";
			}

			if (!string.IsNullOrWhiteSpace(videoId))
			{
				basePath = $"{basePath}videoId={videoId}&";
			}

			if (!string.IsNullOrWhiteSpace(videoTitle))
			{
				basePath = $"{basePath}videoTitle={videoTitle}&";
			}

			if (states != null)
			{
				foreach (var state in states)
				{
					basePath = $"{basePath}state={state}&";
				}
			}

			if (order != null)
			{
				basePath = $"{basePath}orderby={order.Value}&";
			}

			if (direction != null)
			{
				basePath = $"{basePath}direction={direction.Value}&";
			}

			while (basePath.EndsWith("&"))
			{
				basePath = basePath.Remove(basePath.Length - 1);
			}

			if (basePath.EndsWith("?"))
			{
				basePath.Remove(basePath.Length - 1);
			}

			return basePath;
		}
	}
}
