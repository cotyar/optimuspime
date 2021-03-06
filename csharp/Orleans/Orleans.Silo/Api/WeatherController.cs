﻿using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Orleans.Grains.Sample;
using Orleans.Grains.Sample.Models;

namespace Orleans.Silo.Api
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IGrainFactory factory;

        public WeatherController(IGrainFactory factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        public Task<ImmutableArray<WeatherInfo>> GetAsync() =>
            factory.GetGrain<IWeatherGrain>(Guid.Empty).GetForecastAsync();
    }
}