using System;
using System.ComponentModel;
using STFU.Lib.Youtube.Interfaces.Model.Enums;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeJob : ITriggerDeletion, INotifyPropertyChanged
	{
		/// <summary>
		/// the video that is being uploaded
		/// </summary>
		IYoutubeVideo Video { get; }

		/// <summary>
		/// the channel the video is being uploaded to
		/// </summary>
		IYoutubeAccount Account { get; }

		/// <summary>
		/// current state of the job
		/// </summary>
		UploadState State { get; }

		/// <summary>
		/// Determines if the video is being uploaded right now. Is true if job is paused
		/// </summary>
		bool IsUploading { get; }

		/// <summary>
		/// Determines if the upload job is paused
		/// </summary>
		bool IsUploadPaused { get; }

		/// <summary>
		/// current progress of the job
		/// </summary>
		double Progress { get; }

		/// <summary>
		/// Contains information about the error if something fails
		/// </summary>
		IYoutubeError Error { get; }

		/// <summary>
		/// Time the Job has being uploaded
		/// </summary>
		TimeSpan UploadedDuration { get; }

		/// <summary>
		/// Remaining Time the Job will probably need to finish uploading
		/// </summary>
		TimeSpan RemainingDuration { get; }

		/// <summary>
		/// Determines if the jobs upload should be skipped if <see cref="IYoutubeUploader"/> searches for a new job to upload.
		/// Setting this property does not have any effect if the upload has already been started.
		/// Starting the job using <see cref="UploadAsync"/> will not work if this property is true.
		/// Starting the job using <see cref="ForceUploadAsync"/> will ignore this property and start the job immediately.
		/// </summary>
		bool ShouldBeSkipped { get; set; }

		/// <summary>
		/// Starts the jobs upload only if <see cref="ShouldBeSkipped"/> is false
		/// </summary>
		void UploadAsync();

		/// <summary>
		/// Starts the jobs upload even if <see cref="ShouldBeSkipped"/> is true
		/// </summary>
		void ForceUploadAsync();

		/// <summary>
		/// Cancels the Jobs Upload
		/// </summary>
		void CancelUploadAsync();

		/// <summary>
		/// Pauses the Jobs Upload
		/// </summary>
		void PauseUploadAsync();

		/// <summary>
		/// Resumes a paused jobs upload
		/// </summary>
		void ResumeUploadAsync();

		/// <summary>
		/// Will first call <see cref="CancelUploadAsync"/> to cancel the upload if running.
		/// Triggers the deletion of this Job via <see cref="ITriggerDeletion"/> interface event.
		/// This will notify parents that the job should be removed from queues or similar.
		/// </summary>
		void DeleteAsync();

		/// <summary>
		/// Determines if the Jobs underlying video is being edited at the moment
		/// </summary>
		bool IsInEditMode { get; }

		/// <summary>
		/// Sets the Job into edit mode which causes a running job not to success until FinishEdit() is being called.
		/// </summary>
		void BeginEdit();

		/// <summary>
		/// Finishes the Jobs edit mode.
		/// </summary>
		void FinishEdit();
	}
}
