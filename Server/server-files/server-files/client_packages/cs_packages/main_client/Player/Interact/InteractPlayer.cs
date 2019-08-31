using System;
using System.Collections.Generic;
using System.Text;
using RAGE;
using EAPI = RAGE.Elements;
using GAPI = RAGE.Game;
using Newtonsoft.Json;


namespace main_client.Player.Interact
{
    /*class InteractionManager
    {
        class SyncInteraction : Events.Script
        {
            public delegate void InteractionEvent(EAPI.Entity entity);
            public List<InteractionEvent> list_function = new List<InteractionEvent>();

            public SyncInteraction()
            {
                list_function.Add(vehicle_lock_closest_key);
                list_function.Add(vehicle_boot_closest_key);
                list_function.Add(object_closest_key);
                list_function.Add(id_card_closest);
                list_function.Add(inventory_open);
                list_function.Add(MakeScene);
                list_function.Add(ReloadModel);
                /*list_function.Add(vehicle_lock_closest_key);
                list_function.Add(vehicle_boot_closest_key);
                list_function.Add(vehicle_lock_closest_key);
                list_function.Add(vehicle_boot_closest_key);
            }

            private void ReloadModel(EAPI.Entity entity)
            {
                Events.CallRemote("update_skin");
            }

            private void MakeScene(EAPI.Entity entity)
            {
                Events.CallLocal("MakeScene");
            }

            private void inventory_open(EAPI.Entity entity)
            {
                Events.CallLocal("ChangeOpenInteraction", false);
                Events.CallLocal("ChangeOpenInventory", true);
                Events.CallLocal("destroyBrowser", "interaction_form");
                Events.CallLocal("createBrowser", "inventory_form", "package://inventory_system/home.html");
                Events.CallLocal("executeFunction", "inventory_form", "make_matrix", "inventory", 10, 1);
                Events.CallLocal("executeFunction", "inventory_form", "add_item", "{\"id_icon\":0,\"name\":\"Billet\",\"menu\":\"inventory\",\"stock\":2,\"slot\":0,\"id_object\":[2183721]}");
            }

            private void id_card_closest(EAPI.Entity entity)
            {
                Chat.Output("Give IdCard");
                Events.CallRemote("GiveIdCard", RAGE.Elements.Player.LocalPlayer.RemoteId);
            }

            private void vehicle_lock_closest_key(EAPI.Entity entity)
            {
                if (entity.Type != EAPI.Type.Vehicle)
                    return;
                EAPI.Vehicle veh = (EAPI.Vehicle)entity;
                var jsonData = veh.GetSharedData("StreamInVehicle");
                
                if (jsonData == null)
                    return;
                Vehicule.VehicleStreamSync.SyncVehicleData result = JsonConvert.DeserializeObject<Vehicule.VehicleStreamSync.SyncVehicleData>(jsonData.ToString());
                result.IsLock = !result.IsLock;
                Events.CallRemote("UpdateVehicleData", JsonConvert.SerializeObject(result), veh.RemoteId);
            }

            private void vehicle_boot_closest_key(EAPI.Entity entity)
            {
                if (entity.Type != EAPI.Type.Vehicle)
                    return;
                EAPI.Vehicle veh = (EAPI.Vehicle)entity;
                var jsonData = veh.GetSharedData("StreamInVehicle");

                if (jsonData == null)
                    return;

                Vehicule.VehicleStreamSync.SyncVehicleData result = JsonConvert.DeserializeObject<Vehicule.VehicleStreamSync.SyncVehicleData>(jsonData.ToString());
                result.IsBootOpen = !result.IsBootOpen;
                Events.CallRemote("UpdateVehicleData", JsonConvert.SerializeObject(result), veh.RemoteId);
            }

            private void object_closest_key(EAPI.Entity entity)
            {
                Chat.Output("Get object");
                Events.CallLocal("ActiveWorld", new object[] { true });
            }
        }


        class InteractPlayer : Events.Script
        {
            int clock = 0;
            float max = 5f;
            bool open = false;
            List<EAPI.Entity> StreamIn = new List<EAPI.Entity>();
            SyncInteraction sync = new SyncInteraction();

            List<string> vehicle_bone = new List<string>() {
               "bonnet",
                "bumper_f",
                "bumper_r",
                "door_dside_f",
                "window_lf",
                "handle_dside_f",
                "door_dside_r",
                "window_lr",
                "handle_dside_r",
                "window_rr",
                "handle_pside_r",
                "window_rf",
                "handle_pside_f",
                "windscreen_r",
                "windscreen",  
                "suspension_lr",   
                "suspension_lf",   
                "suspension_rf", 
                "suspension_rr",   
                "wing_lf",     
                "wing_lf", 
                "boot",
                "reversinglight_r",
                "reversinglight_l", 
                "platelight",
                "indicator_rr", 
                "indicator_lr",
                "indicator_lf",
                "indicator_rf",
                "headlight_r", 
                "headlight_l", 
                "taillight_l", 
                "taillight_r", 
                "engine",
                "exhaust",
                "exhaust_2",
                "seat_dside_f",  
                "seat_dside_f",  
                "seat_pside_r",  
                "seat_pside_r",  
                "overheat_2", 
                "overheat", 
                "interiorlight",
                "hub_lf",
                "hub_rf",
                "hub_lr",
                "hub_rr",
                "wheel_lf",
                "wheelmesh_lf",
                "wheelmesh_lf_l1",
                "wheelmesh_lf_l2",
                "wheelmesh_lf_ng",
                "wheel_lr", 
                "wheel_rr", 
                "wheel_rf", 
                "bodyshell",
                "misc_a", 
                "misc_b", 
                "slipstream_l",
                "slipstream_r",
                "neon_l",  
                "neon_r",  
                "neon_f",  
                "neon_b",  
                "dashglow",
                "steeringwheel",
                "dials",
                "chassis_dummy",

            };

            public InteractPlayer()
            {
                Events.Tick += Tick;
                Events.Add("ChangeOpenInteraction", ChangeOpenInteraction);
                Events.Add("CallActionCEFtoClient", CallActionCEFtoClient);
                Events.OnEntityStreamIn += OnEntityStreamIn;
                Events.OnEntityStreamOut += OnEntityStreamOut;
            }

            private void ChangeOpenInteraction(object[] args)
            {
                open = (bool)args[0];
            }

            private void CallActionCEFtoClient(object[] args)
            {
                int select = Convert.ToInt32(args[0]);
                int type = Convert.ToInt32(args[1]);
                Chat.Output("Cef " + select + " " + type);
                if (select == 84)
                {
                    Events.CallLocal("destroyBrowser", "interaction_form");
                    open = false;
                    RAGE.Ui.Cursor.Visible = false;
                }
                //else if (get_type_closest((EAPI.Type)type) != null || get_object_closest() != null)
                    sync.list_function[select](get_type_closest((EAPI.Type)type));
            }

            private void OnEntityStreamIn(EAPI.Entity entity)
            {
                if (!StreamIn.Contains(entity))
                {
                    Chat.Output("Stream IN "+entity.Type.ToString());
                    StreamIn.Add(entity);
                }
            }

            private void OnEntityStreamOut(EAPI.Entity entity)
            {
                if (StreamIn.Contains(entity))
                    StreamIn.Remove(entity);
            }

            EAPI.Entity get_type_closest(EAPI.Type type)
            {
                EAPI.Entity tmp = null;
                foreach (EAPI.Entity entity in StreamIn)
                {
                    if (type == entity.Type && entity.Position.DistanceTo(EAPI.Player.LocalPlayer.Position) < max)
                    {
                        tmp = entity;
                        max = entity.Position.DistanceTo(EAPI.Player.LocalPlayer.Position);
                    }
                }
                max = 2f;
                return tmp;
            }

            main_client.World.WorldObjectSync get_object_closest()
            {
                main_client.World.WorldObjectSync tmp = null;
                foreach (var citem in main_client.World.WorldItemSync.current_world_object)
                {
                    if (RAGE.Elements.Player.LocalPlayer.Position.DistanceTo(new Vector3(citem.x, citem.y, citem.z)) < max)
                    {
                        tmp = citem;
                        max = new Vector3(citem.x, citem.y, citem.z).DistanceTo(EAPI.Player.LocalPlayer.Position);
                    }
                }
                max = 1f;
                return tmp;
            }

            void open_menu()
            {
                if (Input.IsDown((int)ConsoleKey.UpArrow) && clock == 0)
                {
                    if (open)
                    {
                        Events.CallLocal("destroyBrowser", "interaction_form");
                        RAGE.Ui.Cursor.Visible = false;
                        open = false;
                    }
                    else
                    {
                        Events.CallLocal("createBrowser", "interaction_form", "package://menu2/index.html");
                        //Events.CallLocal("createBrowser", "phone_form", "package://Phone/index.html");
                        RAGE.Ui.Cursor.Visible = true;
                        open = true;
                    }
                    clock++;
                }
                else if (clock != 0 && clock <= 80)
                    clock++;
                else if (clock >= 80)
                    clock = 0;
            }

            void if_open()
            {
                EAPI.Entity tmp = null;
                if ((tmp = get_type_closest(EAPI.Type.Player)) != null)
                {
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c5", "Donner_De L'Argent", 0);
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c6", "Donner_Un Object", 0);
                    RAGE.Game.Graphics.DrawBox(tmp.Position.X, tmp.Position.Y, tmp.Position.Z, tmp.Position.X + 1, tmp.Position.Y + 1, tmp.Position.Z + 1, 255, 0, 0, 0xFF);
                } else {
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c5", "Indisponible", 1);
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c6", "Indisponible", 1);
                }
                if ((tmp = get_type_closest(EAPI.Type.Vehicle)) != null)
                {
                    //var jsonData = tmp.GetSharedData("VehicleDataStream");
                    //Vehicule.VehicleStreamSync.SyncVehicleData data = JsonConvert.DeserializeObject<Vehicule.VehicleStreamSync.SyncVehicleData>(jsonData.ToString());
                    /*if (data != null)
                    {
                        if (data.IsLock)
                            Events.CallLocal("executeFunction", "interaction_form", "active_button", "c2", "Ouvrir_le vehicule", 0);
                        else
                            Events.CallLocal("executeFunction", "interaction_form", "active_button", "c2", "Fermer_le vehicule", 0);

                        if (data.IsBootOpen)
                            Events.CallLocal("executeFunction", "interaction_form", "active_button", "c1", "Ouvrir_le coffre", 0);
                        else
                            Events.CallLocal("executeFunction", "interaction_form", "active_button", "c1", "Fermer_le coffre", 0);
                    }
                    EAPI.Vehicle veh = (EAPI.Vehicle)tmp;
                    foreach (string bone in vehicle_bone) {
                        Vector3 pos = RAGE.Game.Entity.GetWorldPositionOfEntityBone(veh.Handle, RAGE.Game.Entity.GetEntityBoneIndexByName(veh.Handle, bone));
                        RAGE.Game.Graphics.DrawBox(pos.X - 0.1f, pos.Y - 0.1f, pos.Z - 0.1f, pos.X + 0.1f, pos.Y + 0.1f, pos.Z + 0.1f, 255, 0, 0, 0xFF);

                    }
                    RAGE.Game.Graphics.DrawBox(tmp.Position.X, tmp.Position.Y, tmp.Position.Z, tmp.Position.X + 1, tmp.Position.Y + 1, tmp.Position.Z + 1, 255, 0, 0, 0xFF);
                }
                else
                {
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c2", "Indisponible", 1);
                    Events.CallLocal("executeFunction", "interaction_form", "active_button", "c1", "Indisponible", 1);
                }
            }

            private void Tick(List<Events.TickNametagData> nametags)
            {
                open_menu();
                if (open)
                {
                    if_open();
                }
            }
        }
    }*/
}
