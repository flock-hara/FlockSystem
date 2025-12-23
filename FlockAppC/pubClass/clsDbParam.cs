namespace FlockAppC.pubClass
{
    public class ClsDbParam
    {
        // データベース接続時 ID/Password/DatabaseName/Instance
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string Instance { get; set; }
        public string ConnectString { get; set; }
    }
}
