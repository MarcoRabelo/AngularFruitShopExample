namespace FruitShop.Application.Wrappers
{
    public class Response<TEntity>
    {
        public Response()
        {
        }

        public Response(TEntity data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public TEntity Data { get; set; }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public string Message { get; set; }
    }
}
