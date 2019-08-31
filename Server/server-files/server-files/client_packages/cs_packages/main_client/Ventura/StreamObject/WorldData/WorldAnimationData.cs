using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using Newtonsoft.Json;
using main_client.Ventura.StreamObject.DataModel;

namespace main_client.Ventura.StreamObject.WorldData
{
    [JsonObject]
    class WorldAnimationData : DataModel.DataModel
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long tick { get; set; }
        public virtual string Dict { get; set; }
        public virtual string Anim { get; set; }
        public virtual float Speed { get; set; }
        public virtual int Flags { get; set; }
        public virtual float SpeedMultiplier { get; set; }
        public virtual int Duration { get; set; }
        public virtual bool LockX { get; set; }
        public virtual bool LockY { get; set; }
        public virtual bool LockZ { get; set; }
        public virtual float Playback { get; set; }
        public virtual WorldAnimationData next { get; set; }

        [JsonIgnore]
        private string data_name = main_client.Ventura.Constant.Constant.table_data_name[((int)main_client.Ventura.Constant.Constant.UpdateFlagsClient.WorldAnimationData >> 2) - 1];


        public WorldAnimationData() { }
        public WorldAnimationData(RAGE.Elements.Player player)
        {
            this.RemoteId = player.RemoteId;
        }

        public int count_recursive(WorldAnimationData ptr) {
            int len = 0;
            for (int i = 0; ptr != null; i++)
            {
                ptr = ptr.next;
                len++;
            }
            return len;
        }

        public void StreamIn()
        {
            if (IsActive == false && next != null)
            {
                StreamOut();
                next.StreamIn();
            }
            if (IsActive == false)
            {
                StreamOut();
                return;
            }

            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);
            //Chat.Output("Anim " + Anim + " "+ DateTime.Now.Ticks + " "+ tick);
            if (target == null || target.Handle == 0)
                return;
            if (!RAGE.Game.Entity.IsEntityPlayingAnim(target.Handle, Dict, Anim, 3) && IsActive == true)
            {
                RAGE.Game.Streaming.RequestAnimDict(Dict);
                while (!RAGE.Game.Streaming.HasAnimDictLoaded(Dict)) { RAGE.Game.Invoker.Wait(0); }
                RAGE.Game.Ai.TaskPlayAnim(target.Handle, Dict, Anim, Speed, SpeedMultiplier, Duration, Flags, Playback, LockX, LockY, LockZ);
            }
            else if (RAGE.Elements.Player.LocalPlayer.Handle == target.Handle && DateTime.Now.Ticks > tick)
            {
                WorldAnimationData data = null;
                if (RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name) != null)
                    data = JsonConvert.DeserializeObject<WorldAnimationData>(RAGE.Elements.Player.LocalPlayer.GetSharedData(data_name).ToString());
                if (data == null)
                    return;
                WorldAnimationData ptr = data;
                while (ptr != null) {
                    if (ptr.Id == Id)
                    {
                        ptr.IsActive = false;
                    }
                    ptr = ptr.next;
                }
                RAGE.Elements.Player.LocalPlayer.SetData<string>(data_name, JsonConvert.SerializeObject(data));
                Events.CallRemote("UpdateWorldAnimationData", JsonConvert.SerializeObject(data));
            }
        }

        public void StreamOut()
        {

            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId);

            if (target == null || target.Handle == 0)
                return;
            if (RAGE.Game.Streaming.HasAnimDictLoaded(Dict) && RAGE.Game.Entity.IsEntityPlayingAnim(target.Handle, Dict, Anim, 3) && IsActive == false)
                RAGE.Game.Ai.StopAnimTask(target.Handle, Dict, Anim, 3);
            if (RAGE.Game.Streaming.HasAnimDictLoaded(Dict))
                RAGE.Game.Streaming.RemoveAnimDict(Dict);
            
        }
    }
}
