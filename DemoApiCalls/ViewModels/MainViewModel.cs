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
                    Text += "Request for all inputs initiated.\n\n";
                    response = await APICallsService.GetAllInputsFromAPI();
                    Text += "Request for all inputs completed.\n\n";
                    break;
                case ApiCallsEnum.GetSpecificInput:
                    Text = string.Empty;
                    Text += "Request for specific input initiated.\n\n";
                    response = await APICallsService.GetSpecificInputFromAPI();
                    Text += "Request for specific input completed.\n\n";
                    break;
                case ApiCallsEnum.GetInputsForSlot1:
                    Text = string.Empty;
                    Text += "Request for input for slot 1 initiated.\n\n";
                    response = await APICallsService.GetInputForSlot1FromAPI();
                    Text += "Request for all input for slot 1 completed.\n\n";
                    break;
                case ApiCallsEnum.SetColors:
                    Text = string.Empty;
                    Text += "Request for colors setting initiated.\n\n";
                    response = await APICallsService.SetColorsOnAPI();
                    Text += "Request for colors setting completed.\n\n";
                    break;
                default:
                    break;
            }


            SetResultToTextBox(response);


        }

        private void SetResultToTextBox(IRestResponse<object> result)
        {
            if (result != null)
            {
                Text += "No answer received from API.\n\n";
                return;
            }
            if (result != null && result.Content != null)
            {
                Text += "Some answer received from API.\n\n";

                if (result.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    Text += "Some answer received from API. Status Code OK.\n\n";
                    try
                    {
                        var deserializedresponse = JsonConvert.DeserializeObject(result.Content);
                        Text += $"Response from API: {deserializedresponse}\n\n";
                    }
                    catch (Exception ex)
                    {

                        Text += $"Error receiving data from API. Error: {ex.Message}\n\n";
                    }
                }
            }
        }

        #endregion
    }
}
