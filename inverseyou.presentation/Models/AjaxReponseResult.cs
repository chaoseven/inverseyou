namespace inverseyou.presentation.Models
{
    public class AjaxReponseResult
    {
        public AjaxReponseResult(ResponseState responseState,object responseData,string errorMessage)
        {
            ResponseState = ResponseState;
            ResponseData = responseData;
            ErrorMessage = errorMessage;
        }

        public ResponseState ResponseState { get; set; }
        public object ResponseData { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ResponseState
    {
        Sucess,
        Fail,
        Exception
    }
}
