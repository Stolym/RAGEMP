using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using GTANetworkAPI;
using main.Ventura.Engine.Item;
using main.Ventura.Engine.Stack;


namespace main.Ventura.World
{

    /*
    "CLEAR"  
    "EXTRASUNNY"  
    "CLOUDS"  
    "OVERCAST"  
    "RAIN"  
    "CLEARING"  
    "THUNDER"  
    "SMOG"  
    "FOGGY"  
    "XMAS"  
    "SNOWLIGHT"  
    "BLIZZARD"  
     */




    class WorldWeather : Script
    {
        public List<List<object>> ListWeather { get; set; }

        public WorldWeather() {
            InitializeWeather();
        }

        public void InitializeWeather() {
            ListWeather = new List<List<object>>() {
                new List<object>() { 0, 0.3f, 0.8f, 0.2f, 0.3f, 0.8f, 0.2f, 25, 25, 5, 5, 5, 5, 5, 5, 5, "CLEAR" },

            };
        }

        [ServerEvent(Event.Update)]
        public void UpdateWeather() {
            StartClock();
            OnTick();
        }

        public void StartClock() {
            for (int i = 0; i < ListWeather.Count; i++) {
                if ((long)ListWeather[i][0] == 0)
                    ListWeather[i][0] = DateTime.Now.AddHours(2).Ticks;
            }
        }

        public void OnTick() {
            for (int i = 0; i < ListWeather.Count; i++) {
                if ((long)ListWeather[i][0] < DateTime.Now.Ticks)
                    UpdateRandomWeather(ListWeather[i]);

    class WorldWeather : Script
    {
        public List<List<object>> ListWeather { get; set; }

        public WorldWeather() {
            InitializeWeather();
        }

        public void InitializeWeather() {
            ListWeather = new List<List<object>>() {
                new List<object>() { 0, 0.3f, 0.8f, 0.2f, 0.3f, 0.8f, 0.2f, 25, 25, 5, 5, 5, 5, 5, 5, 5, "CLEAR" },

            };
        }

        [ServerEvent(Event.Update)]
        public void UpdateWeather() {
            StartClock();
            OnTick();
        }

        public void StartClock() {
            for (int i = 0; i < ListWeather.Count; i++) {
                if ((long)ListWeather[i][0] == 0)
                    ListWeather[i][0] = DateTime.Now.AddHours(2).Ticks;
            }
        }

        public void OnTick() {
            for (int i = 0; i < ListWeather.Count; i++) {
                if ((long)ListWeather[i][0] < DateTime.Now.Ticks)
                    UpdateRandomWeather(ListWeather[i]);

            }
        }

        public void UpdateRandomWeather(List<object> weather) 
        {
            (long)weather[0] = 0;
            List<int> randValue = GetRandomValue(weather);

        }

        public List<int> GetRandomValue(List<object> weather) 
        {
            List<int> list = new List<int>();

            for (int i = 6; i < weather.Count; i++)
                list.Add((int)weather);
        }


    }


            }
        }

        public void UpdateRandomWeather(List<object> weather) 
        {
            (long)weather[0] = 0;
            List<int> randValue = GetRandomValue(weather);

        }

        public List<int> GetRandomValue(List<object> weather) 
        {
            List<int> list = new List<int>();

            for (int i = 6; i < weather.Count; i++)
                list.Add((int)weather);
        }


    }



}