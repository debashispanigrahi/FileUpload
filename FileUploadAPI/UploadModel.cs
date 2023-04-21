using System;
namespace FileUploadAPI
{
	public class InputModel
	{
		public string FileData { get; set; }
	}

    public class UploadModel
	{
		public byte[] FileBytes { get; set; }
		public string FileName { get; set; }
	}
}

