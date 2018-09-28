using System.Collections.Generic;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

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
		/// Current State of the uploader
		/// </summary>
		UploaderState State { get; }

		/// <summary>
		/// Gets the queue with all waiting jobs. Videos will be uploaded in this particular order.
		/// </summary>
		IReadOnlyCollection<IYoutubeJob> Queue { get; }

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
		/// Requests the uploader to cancel a currently running job.
		/// </summary>
		void CancelJob(IYoutubeJob job);

		/// <summary>
		/// Adds a job to queue.
		/// </summary>
		/// <param name="job"></param>
		/// <exception cref="ArgumentException">Thrown when Job is already contained in queue.</exception>
		IYoutubeJob QueueUpload(IYoutubeVideo video, IYoutubeAccount account);

		/// <summary>
		/// Removes a job from queue.
		/// </summary>
		/// <param name="job"></param>
		/// <exception cref="ArgumentException">Thrown when Job is not contained in queue.</exception>
		void RemoveFromQueue(IYoutubeJob job);

		/// <summary>
		/// switches two jobs in queue.
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <exception cref="ArgumentException">Thrown when at least one Job is not contained in queue.</exception>
		void ChangePositionInQueue(IYoutubeJob first, IYoutubeJob second);
	}
}
