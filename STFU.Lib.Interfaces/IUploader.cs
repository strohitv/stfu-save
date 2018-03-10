using System.Threading.Tasks;
using STFU.Lib.Interfaces.Model;

namespace STFU.Lib.Interfaces
{
	public interface IUploader
	{
		Task UploadVideoAsync(IVideo video, IAccount account);

		void UploadVideo(IVideo video, IAccount account);
	}
}
