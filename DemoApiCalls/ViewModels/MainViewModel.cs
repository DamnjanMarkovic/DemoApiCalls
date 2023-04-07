using DemoApiCalls.Models;
using DemoApiCalls.Services;
using Newtonsoft.Json;
using Prism.Commands;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoApiCalls.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        #region Properties

        private string _text = "API CALL RESULT";
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        #endregion



        #region Commands
        public ICommand PerformAPICallCommand => new DelegateCommand<object>(PerformAPICall);
        #endregion

        #region Constructor

        public MainViewModel()
        {
            
        }

        #endregion

        #region Funcs

        private async void PerformAPICall(object enumObject)
        {
            var enumArrived = (ApiCallsEnum)enumObject;
            IRestResponse<object> response = new RestResponse<object>();
            switch (enumArrived)
            {
                case ApiCallsEnum.GetAllInputs:
                    Text = string.Empty;
                    Text += "Request for all inputs initiated.\n";
                    response = await APICallsService.GetAllInputsFromAPI();
                    break;
                case ApiCallsEnum.GetSpecificInput:
                    Text = string.Empty;
                    Text += "Request for specific input initiated.\n";
                    response = await APICallsService.GetSpecificInputFromAPI();
                    break;
                case ApiCallsEnum.GetInputsForSlot1:
                    Text = string.Empty;
                    Text += "Request for input for slot 1 initiated.\n";
                    response = await APICallsService.GetInputForSlot1FromAPI();
                    break;
                case ApiCallsEnum.SetColors:
                    Text = string.Empty;
                    Text += "Request for colors setting initiated.\n";
                    Text += "Sending:\n";
                    Text += $"{APICallsService.PrepareJsonForPost()}.\n\n";
                    response = await APICallsService.SetColorsOnAPI();
                    break;
                default:
                    break;
            }


            SetResultToTextBox(response);

            Text += "Request completed.\n";

        }

        private void SetResultToTextBox(IRestResponse<object> result)
        {
            if (result == null)
            {
                Text += "No answer received from API.\n";
                return;
            }
            if (result != null && result.Content != null)
            {
                Text += "Answer received from API; ";

                if (result.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    Text += "Status Code OK.\n";
                    try
                    {
                        var deserializedresponse = JsonConvert.DeserializeObject(result.Content);
                        Text += $"Response from API: {deserializedresponse}\n";
                    }
                    catch (Exception ex)
                    {

                        Text += $"Error receiving data from API. Error: {ex.Message}\n";
                    }
                }
                else
                {
                    Text += "Status Code NOT OK.\n";
                }
            }
        }

        #endregion
    }
}
