using System;
using System.Collections.Generic;
using System.Text;
using main_client.Ventura.StreamObject.DataModel;
using RAGE;
using Newtonsoft.Json;

namespace main_client.Ventura.StreamObject.WorldData
{
    class WorldSceneData : DataModel.DataModel
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual List<int> RemoteId { get; set; }
        public virtual uint Dimensions { get; set; }
        public virtual Constant.Constant.UpdateFlagsClient Type { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual List<string> Dict { get; set; }
        public virtual List<string> Anim { get; set; }
        public virtual List<float> Speed { get; set; }
        public virtual List<int> Flags { get; set; }
        public virtual List<float> SpeedMultiplier { get; set; }
        public virtual List<int> Duration { get; set; }
        public virtual List<bool> LockX { get; set; }
        public virtual List<bool> LockY { get; set; }
        public virtual List<bool> LockZ { get; set; }
        public virtual DataModel.Vector3 SceneOrigin { get; set; }
        public virtual DataModel.Vector3 SceneRotation { get; set; }
        public virtual List<int> Bone { get; set; }
        public virtual List<float> Playback { get; set; }
        public virtual bool IsObject { get; set; }

        [JsonIgnore]
        private int Scene = 0;


        public WorldSceneData() { }
        public WorldSceneData(RAGE.Elements.Player player)
        {
        }

        public void StreamIn()
        {
            if (IsActive == false)
                return;

            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId[0]);
            RAGE.Elements.Player target_partner = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId[1]);

            
            if (target == null || target.Handle == 0 || target_partner == null || target.Handle == 0)
                return;
            var diff = target.Position - target_partner.Position;
            var midPoint = target.Position + diff * 0.5f;

            // X Y Z RX RY RZ P6

            Scene = RAGE.Game.Ped.CreateSynchronizedScene(midPoint.X, midPoint.Y, target.Position.Z, target.GetRotation(1).X, target.GetRotation(1).Y, target.GetRotation(1).Z, 2);

            // SceneID X Y Z RX RY RZ P6

            RAGE.Game.Ped.SetSynchronizedSceneOrigin(Scene, midPoint.X, midPoint.Y, target.Position.Z, target.GetRotation(1).X, target.GetRotation(1).Y, target.GetRotation(1).Z, false);

            // SceneID Handle Bone

            RAGE.Game.Ped.AttachSynchronizedSceneToEntity(Scene, target.Handle, Bone[0]);
                
            // SceneID Handle Bone

            RAGE.Game.Ped.AttachSynchronizedSceneToEntity(Scene, target_partner.Handle, Bone[1]);

            // Dict

            RAGE.Game.Streaming.RequestAnimDict(Dict[0]);

            // Dict
                
            RAGE.Game.Streaming.RequestAnimDict(Dict[1]);
            while (!RAGE.Game.Streaming.HasAnimDictLoaded(Dict[0])) { RAGE.Game.Invoker.Wait(0); }
            while (!RAGE.Game.Streaming.HasAnimDictLoaded(Dict[1])) { RAGE.Game.Invoker.Wait(0); }
                
            // Handle

            RAGE.Game.Ai.ClearPedTasksImmediately(target.Handle);
            RAGE.Game.Ai.ClearPedTasksImmediately(target_partner.Handle);

            // SM S PBR LX LY LZ

            RAGE.Game.Ai.TaskPlayAnim(target.Handle, Dict[0], Anim[0], Speed[0], 1f, -1, Flags[0], 0, false, false, false);
                
            // SM S D PBR LX LY LZ

            RAGE.Game.Ai.TaskPlayAnim(target_partner.Handle, Dict[1], Anim[1], Speed[1], 1f, -1, Flags[1], 0, false, false, false);

            // SM S D PBR P9

            RAGE.Game.Ai.TaskSynchronizedScene(target.Handle, Scene, Dict[0], Anim[0], Speed[0], 1.0f, 0, Flags[0], 0, 0);

            // SM S D PBR P9
                
            RAGE.Game.Ai.TaskSynchronizedScene(target_partner.Handle, Scene, Dict[1], Anim[1], Speed[1], 1.0f, 0, Flags[1], 0, 0);
            
        }

        public void StreamOut()
        {
            RAGE.Elements.Player target = RAGE.Elements.Entities.Players.All.Find(x => x.RemoteId == RemoteId[0]);

            if (target == null || (target.Handle == 0 && LocalId == 0))
                return;
        }
    }
}
