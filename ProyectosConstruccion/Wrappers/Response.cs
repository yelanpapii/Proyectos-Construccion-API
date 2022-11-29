namespace ProyectosConstruccion.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data)
        {
            Data = data;
            Succeded = true;
            Errors = null;
            Message = string.Empty;
        }

        public T Data { get; set; }
        public bool Succeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}