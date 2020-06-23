﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Entities;
using MongoWebApiStarter.Tests;
using ServiceStack;
using System;

namespace MongoWebApiStarter.Tests_Main
{
    [TestClass]
    public class Account
    {
        private static readonly JsonServiceClient client = new JsonServiceClient(Init.BaseUrl);

        [TestMethod]
        public void Create()
        {
            var guid = Guid.NewGuid().ToString();

            var req = new Main.Account.Save.Request
            {
                City = "city",
                CountryCode = "LKA",
                EmailAddress = $"{guid}@email.com",
                FirstName = "firstname",
                LastName = "surname",
                Mobile = "0773469292",
                Password = "qqqqq123Q",
                State = "state",
                Street = "street",
                Title = "mr.",
                ZipCode = "10100",
            };

            var res = client.Post(req);

            res.EmailSent.Should().BeTrue();
            res.ID.Should().NotBeNullOrEmpty();

            var acc = DB.Find<Data.Account>().One(res.ID);

            acc.Email.Should().BeEquivalentTo(req.EmailAddress);
            acc.IsEmailVerified.Should().BeFalse();
        }
    }
}