using System.Collections.Generic;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Interfaces.Model.Handler;

namespace STFU.Lib.Youtube.Interfaces
{
	public delegate void UploadStarted(UploadStartedEventArgs args);

	public interface IYoutubeUploader: INotifyPropertyChanged
	{
		/// <summary>
		/// Gets or sets if the uploader should remove jobs when they are completed
		/// </summary>
		bool RemoveCompletedJobs { get; set; }

		/// <summary>
		/// Gets or sets if the uploader should stop after it completed the last upload in queue
		/// </summary>
		bool StopAfterCompleting { get; set; }

		/// <summary>
		/// Gets or sets the maximum amount of videos that may be uploaded at a time
		/// </summary>
		int MaxSimultaneousUploads { get; set; }

		/// <summary>
		/// Gets the current average progress of all running jobs
		/// </summary>
		int Progress { get; }

		/// <summary>
		/// Gets or sets if the Uploader should limit its jobs upload speed
		/// </summary>
		bool LimitUploadSpeed { get; set; }

		/// <summary>
		/// Gets or sets the speed each job is allowed to upload
		/// </summary>
		long UploadLimitKByte { get; set; }

		/// <summary>
		/// Current State of the uploader
		/// </summary>
		UploaderState State { get; }

		/// <summary>
		/// Gets the queue with all waiting jobs. Videos will be uploaded in this particular order.
		/// </summary>
		IReadOnlyCollection<IYoutubeJob> Queue { get; }

		/// <summary>
		/// Will be fired as soon as a new Upload is being started
		/// </summary>
		event UploadStarted NewUploadStarted;

		/// <summary>
		/// Starts the uploader and lets it run async. 
		/// It will upload all Videos in queue.
		/// To set if it should stop or wait for new jobs after uploading the last job use <see cref="StopAfterCompleting"/> property.
		/// </summary>
		void StartUploader();

		/// <summary>
		/// Requests the uploader to cancel immediately.
		/// </summary>
		void CancelAll();

		/// <summary>
		/// Adds a job to queue.
		/// </summary>
		/// <param name="video"></param>
		/// <param name="account"></param>
		IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account, INotificationSettings notificationSettings);

		/// <summary>
		/// Adds a job to queue.
		/// </summary>
		/// <param name="job"></param>
		IYoutubeJob QueueUpload(IYoutubeJob job);

		/// <summary>
		/// Removes a job from queue.
		/// </summary>
		/// <param name="job"></param>
		void RemoveFromQueue(IYoutubeJob job);

		/// <summary>
		/// Switches a jobs Position in queue
		/// </summary>
		/// <param name="job"></param>
		/// <param name="newPosition"></param>
		void ChangePosition(IYoutubeJob job, int newPosition);

		/// <summary>
		/// Fired when a new Upload is added to the queue
		/// </summary>
		event JobQueuedEventHandler JobQueued;

		/// <summary>
		/// Fired when a Upload is removed from the queue
		/// </summary>
		event JobDequeuedEventHandler JobDequeued;

		/// <summary>
		/// Fired when a Upload is removed from the queue
		/// </summary>
		event JobPositionChangedEventHandler JobPositionChanged;
	}
}
