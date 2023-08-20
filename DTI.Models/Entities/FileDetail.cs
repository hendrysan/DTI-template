namespace DTI.Models.Entities
{
    public class FileDetail
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileBase64 { get; set; }
        public string Extension { get; set; }

    }
}
