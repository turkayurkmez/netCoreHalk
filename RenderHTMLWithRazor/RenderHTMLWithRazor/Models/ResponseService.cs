namespace RenderHTMLWithRazor.Models
{
    public static class ResponseService
    {
        private static List<ResponseModel> responses = new List<ResponseModel>();
        public static void AddResponse(ResponseModel response)
        {
            responses.Add(response);
        }

        public static List<ResponseModel> GetResponses()
        {
            return responses;
        }


    }
}
