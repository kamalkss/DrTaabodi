using System;


namespace DrTaabodi.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSucceess { get; set; }
        public string Messege { get; set; }
        public DateTime Time { get; set; }
        public T Data { get; set; }


        

    }
}
