﻿using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyStore.Api.Controllers
{
    [RoutePrefix("api/v1/account")]
    public class AccountController : BaseController
    {
        private readonly IUserApplicationService _service;

        public AccountController(IUserApplicationService userService)
        {
            _service = userService;
        }

        [HttpPost]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                email: (string)body.email,
                username: (string)body.username,
                password: (string)body.password
                );

            var user = _service.Register(command);
            return CreateResponse(System.Net.HttpStatusCode.Created, user);
        }
    }
}