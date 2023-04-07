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
using System.Windows;
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

        private string _urlString;
        public string UrlString
        {
            get
            {
                return _urlString;
            }
            set
            {
                _urlString = value;
                OnPropertyChanged(nameof(UrlString));
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
            if (string.IsNullOrEmpty(UrlString))
            {
                MessageBox.Show("Please enter URL");
                return;
            }

            string url = string.Empty;


            var enumArrived = (ApiCallsEnum)enumObject;
            IRestResponse<object> response = new RestResponse<object>();
            switch (enumArrived)
            {
                case ApiCallsEnum.GetAllInputs:
                    Text = string.Empty;
                    Text += "Request for all inputs initiated.\n";
                    url = $"{UrlString}/v1/inputs";
                    Text += $"URL: {url}\n";
                    response = await APICallsService.GetAllInputsFromAPI(url);
                    break;
                case ApiCallsEnum.GetSpecificInput:
                    Text = string.Empty;
                    Text += "Request for specific input initiated.\n";
                    url = $"{UrlString}/v1/inputs/0";
                    Text += $"URL: {url}\n";
                    response = await APICallsService.GetSpecificInputFromAPI(url);
                    break;
                case ApiCallsEnum.GetInputsForSlot1:
                    Text = string.Empty;
                    Text += "Request for input for slot 1 initiated.\n";
                    url = $"{UrlString}/v1/inputs?slot-num=1";
                    Text += $"URL: {url}\n";
                    response = await APICallsService.GetInputForSlot1FromAPI(url);
                    break;
                case ApiCallsEnum.SetColors:
                    Text = string.Empty;
                    Text += "Request for colors setting initiated.\n";
                    Text += "Sending:\n";
                    Text += $"{APICallsService.PrepareJsonForPost()}.\n\n";
                    url = $"{UrlString}/v1/inputs";
                    Text += $"URL: {url}\n";
                    response = await APICallsService.SetColorsOnAPI(url);
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
