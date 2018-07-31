namespace CalibrationFileEditer
{
    public class DataProvider
    {
        private string data;
        public DataProvider(string data)
        {
            SetData(data);
        }
        public string GetData()
        {
            return data;
        }
        public void SetData(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                this.data = data;
            }
        }
    }
}