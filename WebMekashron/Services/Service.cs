using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMekashron.Models;
using WebMekashron.Extensions;
using WebMekashron.Helpers;
using WebMekashron.ServiceReference;
using WebMekashron.Security;
using LoginResponse = WebMekashron.Models.LoginResponse;

namespace WebMekashron.Services
{
    public class Service
    {

        public LoginResponse GetByLogin(string username, string password, string ip, ref string error)
        {
            using (var client = new ICUTechClient())
            {
                WcfConfigure.Authorize(client);

                var request = client.Login(username, password, ip);
                var response = request.Decode<ResultResponse>();

                if (response.ResultCode == -1)
                {
                    error = response.ResultMessage;
                    return null;
                }

                var result = request.Decode<LoginResponse>();

                return result;
            }
        }

        public CustomerInfoResponse GetByEntity(string username, string password, int id, ref string error)
        {
            using (var client = new ICUTechClient())
            {
                WcfConfigure.Authorize(client);

                var request = client.GetCustomerInfo(id, username, password);
                var response = request.Decode<ResultResponse>();

                if (response.ResultCode == -1)
                {
                    error = response.ResultMessage;
                    return null;
                }

                var result = request.Decode<CustomerInfoResponse>();

                return result;
            }
        }

        public int NewCustomer(string username, string password, string firstName, string lastName, string phone, int? country, string ip, ref string error)
        {
            using (var client = new ICUTechClient())
            {
                WcfConfigure.Authorize(client);

                var request = client.RegisterNewCustomer(username, password, firstName, lastName, phone, country ?? 1, 1, ip);
                var response = request.Decode<ResultResponse>();
                if (response.ResultCode == -1)
                {
                    error = response.ResultMessage;
                    return -1;
                }

                var result = request.Decode<NewCustomerResponse>();

                return result.EntityId;
            }
        }

    }
}