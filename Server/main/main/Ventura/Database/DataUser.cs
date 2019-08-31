using System;
using System.Collections.Generic;
using System.Text;
using ZeroFormatter;
using FAPI = main.Ventura.Database.Formatter.Formatter;
using Newtonsoft.Json;
using main.Ventura.Engine.Inventory;

namespace main.Ventura.Database
{
    /*
         * Identity
         * User
         * Heatlh
         * RigidBody
         * Cloth
         * Body
         * Tattoo
         * Bank
         * item
         * Jobs Permission
         * 
         * 
         * Vehicle if not exist in instance server(out after 2 hour)
          * Habitation sender
          * Cloth sender
          * Market sender
          * Object sender
          * Seed sender
          * Door sender
          * Attach Object Sender
          * Animation sender
          * Seat sender
          * State sender
          * 
          * */

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*[ZeroFormattable]
    public class Vector3 {
    
        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3() {
            x = 0;
            y = 0;
            z = 0;
        }

        [Index(0)]
        public virtual float x { get; set; }
        [Index(1)]
        public virtual float y { get; set; }
        [Index(2)]
        public virtual float z { get; set; }
    }*/

    [JsonObject]
    public class Vector3 {

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public virtual float x { get; set; }
        public virtual float y { get; set; }
        public virtual float z { get; set; }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*[ZeroFormattable]
    public class Scene
    {
        public Scene() { }

        public void SetDefault() {
            IsActive = false;
            IsObject = false;
            ID = 0;
            Name = "";
            LocalId = 0;
            RemoteId = new List<uint>() { 0, 0 };
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldSceneData;
            Dict = new List<string>() { "", "" };
            Anim = new List<string>() { "", "" };
            Speed = new List<float>() { 4f, 4f };
            SpeedMultiplier = new List<float>() { 1f, 1f };
            Duration = new List<int>() { -1, -1 };
            Flags = new List<int>() { (int)Constant.Constants.AnimationFlags.Loop, (int)Constant.Constants.AnimationFlags.Loop  };
            LockX = new List<bool>() { false, false };
            LockY = new List<bool>() { false, false };
            LockZ = new List<bool>() { false, false };
            Playback = new List<float>() { 0f, 0f };
            Bone = new List<int>() { 28644, 28644 };
            SceneOrigin = new Vector3();
            SceneRotation = new Vector3();
        }


        [Index(0)]
        public virtual int ID { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual List<uint> RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }

        [Index(6)]
        public virtual bool IsActive { get; set; }

        [Index(7)]
        public virtual List<string> Dict { get; set; }

        [Index(8)]
        public virtual List<string> Anim { get; set; }

        [Index(9)]
        public virtual List<float> Speed { get; set; }

        [Index(10)]
        public virtual List<int> Flags { get; set; }

        [Index(11)]
        public virtual List<float> SpeedMultiplier { get; set; }

        [Index(12)]
        public virtual List<int> Duration { get; set; }

        [Index(13)]
        public virtual List<bool> LockX { get; set; }

        [Index(14)]
        public virtual List<bool> LockY { get; set; }

        [Index(15)]
        public virtual List<bool> LockZ { get; set; }

        [Index(16)]
        public virtual Vector3 SceneOrigin { get; set; }

        [Index(17)]
        public virtual Vector3 SceneRotation { get; set; }

        [Index(18)]
        public virtual List<int> Bone { get; set; }

        [Index(19)]
        public virtual List<float> Playback { get; set; }

        [Index(20)]
        public virtual bool IsObject { get; set; }
    };*/


    [JsonObject]
    public class Scene {

        public Scene() { }

        public void SetDefault()
        {
            IsActive = false;
            IsObject = false;
            ID = 0;
            Name = "";
            LocalId = 0;
            RemoteId = new List<int>() { 0, 0 };
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldSceneData;
            Dict = new List<string>() { "", "" };
            Anim = new List<string>() { "", "" };
            Speed = new List<float>() { 4f, 4f };
            SpeedMultiplier = new List<float>() { 1f, 1f };
            Duration = new List<int>() { -1, -1 };
            Flags = new List<int>() { (int)Constant.Constants.AnimationFlags.Loop, (int)Constant.Constants.AnimationFlags.Loop };
            LockX = new List<bool>() { false, false };
            LockY = new List<bool>() { false, false };
            LockZ = new List<bool>() { false, false };
            Playback = new List<float>() { 0f, 0f };
            Bone = new List<int>() { 28644, 28644 };
            SceneOrigin = new Vector3();
            SceneRotation = new Vector3();
        }

        public virtual int ID { get; set; }

        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual List<int> RemoteId { get; set; }
        public virtual int Dimensions { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
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
        public virtual Vector3 SceneOrigin { get; set; }
        public virtual Vector3 SceneRotation { get; set; }
        public virtual List<int> Bone { get; set; }
        public virtual List<float> Playback { get; set; }
        public virtual bool IsObject { get; set; }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    [JsonObject]
    public class GVocal {
        public virtual List<string> DimensionsVocal { get; set; }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*[ZeroFormattable]
    public class Attach
    {
        public Attach() { }

        public void SetDefault() {
            ID = 0;
            Name = "";
            LocalId = 0;
            RemoteId = 0;
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldAttachData;
            Bone = 28644;
            IsDynamic = false;
            IsNetwork = true;
            Position = new Vector3();
            Rotation = new Vector3();
            P9 = false;
            UseSoftPinning = false;
            IsPed = false;
            Collision = false;
            LockRotation = false;
        }


        [Index(0)]
        public virtual int ID { get; set; }
        [Index(1)]
        public virtual string Name { get; set; }
        [Index(2)]
        public virtual int LocalId { get; set; }
        [Index(3)]
        public virtual ushort RemoteId { get; set; }
        [Index(4)]
        public virtual int Dimensions { get; set; }
        [Index(5)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        [Index(6)]
        public virtual int Bone { get; set; }
        [Index(7)]
        public virtual bool IsDynamic { get; set; }
        [Index(8)]
        public virtual bool IsNetwork { get; set; }
        [Index(9)]
        public virtual Vector3 Position { get; set; }
        [Index(10)]
        public virtual Vector3 Rotation { get; set; }
        [Index(11)]
        public virtual bool P9 { get; set; }
        [Index(12)]
        public virtual bool UseSoftPinning { get; set; }
        [Index(13)]
        public virtual bool Collision { get; set; }
        [Index(14)]
        public virtual bool IsPed { get; set; }
        [Index(15)]
        public virtual int VertexIndex { get; set; }
        [Index(16)]
        public virtual bool LockRotation { get; set; }
        [Index(17)]
        public virtual uint Hashcode { get; set; }
        [Index(18)]
        public virtual bool IsFakeObject { get; set; }
    }*/

    [JsonObject]
    public class Attach
    {
        public Attach() { }

        public void SetDefault()
        {
            ID = 0;
            Name = "";
            LocalId = 0;
            RemoteId = 0;
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldAttachData;
            Bone = 28644;
            IsDynamic = false;
            IsNetwork = true;
            Position = new Vector3();
            Rotation = new Vector3();
            P9 = false;
            UseSoftPinning = false;
            IsPed = false;
            Collision = false;
            LockRotation = false;
        }

        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual int Dimensions { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual int Bone { get; set; }
        public virtual bool IsDynamic { get; set; }
        public virtual bool IsNetwork { get; set; }
        public virtual Vector3 Position { get; set; }
        public virtual Vector3 Rotation { get; set; }
        public virtual bool P9 { get; set; }
        public virtual bool UseSoftPinning { get; set; }
        public virtual bool Collision { get; set; }
        public virtual bool IsPed { get; set; }
        public virtual int VertexIndex { get; set; }
        public virtual bool LockRotation { get; set; }
        public virtual int Hashcode { get; set; }
        public virtual bool IsFakeObject { get; set; }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*
    [ZeroFormattable]
    public class Animation
    {
        public Animation() {

        }

        public void SetDefault() {
            IsActive = false;
            Dict = "";
            Anim = "";
            Speed = 4f;
            SpeedMultiplier = 4f;
            ID = 0;
            Name = "";
            LocalId = 0;
            RemoteId = 0;
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldAnimationData;
            Flags = (int)Constant.Constants.AnimationFlags.Loop;
            Duration = -1;
            LockX = false;
            LockY = false;
            LockZ = false;
            Playback = 0;
        }

        [Index(0)]
        public virtual int ID { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual int LocalId { get; set; }

        [Index(3)]
        public virtual ushort RemoteId { get; set; }

        [Index(4)]
        public virtual int Dimensions { get; set; }

        [Index(5)]
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }

        [Index(6)]
        public virtual bool IsActive { get; set; }

        [Index(7)]
        public virtual string Dict { get; set; }

        [Index(8)]
        public virtual string Anim { get; set; }

        [Index(9)]
        public virtual float Speed { get; set; }

        [Index(10)]
        public virtual int Flags { get; set; }

        [Index(11)]
        public virtual float SpeedMultiplier { get; set; }

        [Index(12)]
        public virtual int Duration { get; set; }

        [Index(13)]
        public virtual bool LockX { get; set; }

        [Index(14)]
        public virtual bool LockY { get; set; }

        [Index(15)]
        public virtual bool LockZ { get; set; }

        [Index(16)]
        public virtual float Playback { get; set; }
    }*/


    [JsonObject]
    public class Animation
    {
        public Animation()
        {

        }

        public void SetDefault()
        {
            IsActive = false;
            Dict = "";
            Anim = "";
            Speed = 4f;
            SpeedMultiplier = 4f;
            Id = 0;
            Name = "";
            LocalId = 0;
            RemoteId = 0;
            Dimensions = 0;
            Type = Constant.Constants.UpdateFlags.WorldAnimationData;
            Flags = (int)Constant.Constants.AnimationFlags.Loop;
            tick = 0;
            next = null;
            Duration = -1;
            LockX = false;
            LockY = false;
            LockZ = false;
            Playback = 0;
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int LocalId { get; set; }
        public virtual int RemoteId { get; set; }
        public virtual int Dimensions { get; set; }
        public virtual main.Ventura.Constant.Constants.UpdateFlags Type { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Dict { get; set; }
        public virtual string Anim { get; set; }
        public virtual float Speed { get; set; }
        public virtual int Flags { get; set; }
        public virtual float SpeedMultiplier { get; set; }
        public virtual int Duration { get; set; }
        public virtual long tick { get; set; }
        public virtual bool LockX { get; set; }
        public virtual bool LockY { get; set; }
        public virtual bool LockZ { get; set; }
        public virtual float Playback { get; set; }
        public virtual Animation next { get; set; }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*
     * 
     * Walking 
     * 
     * 
     * */




    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*[ZeroFormattable]
    public class RigidBody {

        public RigidBody() { }

        public void SetDefault() {
            IsBreak = new List<bool>();

            for (int i = 0; i < 15; i++) {
                IsBreak.Add(false);
            }
            IsAlive = true;
        }

        [Index(0)]
        public virtual List<bool> IsBreak { get; set; }
        [Index(1)]
        public virtual bool IsAlive { get; set; }
        /*
         * index
         * 0 head
         * 1 chest
         * 2 Back
         * 3 left shoulder
         * 4 right shoulder
         * 5 left arm
         * 6 right arm
         * 7 left forarm
         * 8 right forarm
         * 9 left thigh
         * 10 right thigh
         * 11 left shins
         * 12 right shins
         * 13 left foot
         * 14 right foot
         * */
    [JsonObject]
    public class RigidBody
    {

        public RigidBody() { }

        public void SetDefault()
        {
            IsBreak = new List<bool>();

            for (int i = 0; i < 15; i++)
            {
                IsBreak.Add(false);
            }
            IsAlive = true;
        }
        
        public virtual List<bool> IsBreak { get; set; }
        public virtual bool IsAlive { get; set; }
    };


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*
     * if service
     *  load service
     *  else
     *  body_cloth
     * 
     * */
    /*[ZeroFormattable]
    public class Cloth {

        public Cloth() { }
        
        public void SetDefault(int sex) {
            body_cloth = new List<int[]>();
            Random rand = new Random();
            if (sex == 0) // Femme
            {
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { rand.Next(0, 22), rand.Next(0, 63) });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 2, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 4, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 57, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 3, 0 });
                body_cloth.Add(new int[] { 120, 0 });
                body_cloth.Add(new int[] { 12, 0 });
                body_cloth.Add(new int[] { 12, 0 });
                body_cloth.Add(new int[] { 1, 0 });
                body_cloth.Add(new int[] { 15, 0 });
            }
            else if (sex == 1)
            { // Homme
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { rand.Next(0, 22), rand.Next(0, 63) });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 20, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 12, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 12, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 23, 0 });
                body_cloth.Add(new int[] { 8, 0 });
                body_cloth.Add(new int[] { 0, 0 });
                body_cloth.Add(new int[] { 33, 0 });
                body_cloth.Add(new int[] { 2, 0 });
                body_cloth.Add(new int[] { 0, 0 });
            }
        }

        [Index(0)]
        public virtual List<int[]> body_cloth { get; set; }
    }*/

    [JsonObject]
    public class Cloth
    {
        public virtual List<List<int>> body_cloth { get; set; }

        public Cloth() { }

        public void SetDefault(int sex)
        {
            this.body_cloth = new List<List<int>>();

            switch (sex) {
                case 0:
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 12, 0 });
                    body_cloth.Add(new List<int>() { 20, 1 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 12, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 12, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 23, 0 });
                    body_cloth.Add(new List<int>() { 8, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 33, 0 });
                    body_cloth.Add(new List<int>() { 2, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    break;
                case 1:
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 2, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 4, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 57, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 0, 0 });
                    body_cloth.Add(new List<int>() { 3, 0 });
                    body_cloth.Add(new List<int>() { 120, 0 });
                    body_cloth.Add(new List<int>() { 12, 0 });
                    body_cloth.Add(new List<int>() { 12, 0 });
                    body_cloth.Add(new List<int>() { 1, 0 });
                    body_cloth.Add(new List<int>() { 15, 0 });
                    break;
            }
        }

    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*
    [ZeroFormattable]
    public class Body {
        public Body() { }

        public void SetDefault() {
            ShapeFirst = 0;
            ShapeSecond = 0;
            ShapeThird = 0;
            ShapeMix = 0;
            SkinFirst = 0;
            SkinSecond = 0;
            SkinThird = 0;
            skinMix = 0;
        }

        [Index(0)]
        public virtual byte ShapeFirst { get; set; }

        [Index(1)]
        public virtual byte ShapeSecond { get; set; }

        [Index(2)]
        public virtual byte ShapeThird { get; set; }
        
        [Index(3)]
        public virtual byte SkinFirst { get; set; }
        
        [Index(4)]
        public virtual byte SkinSecond { get; set; }
        
        [Index(5)]
        public virtual byte SkinThird { get; set; }
        
        [Index(6)]
        public virtual float ShapeMix { get; set; }
        
        [Index(7)]
        public virtual float SkinMix { get; set; }
        
        [Index(8)]
        public virtual float ThirdMix { get; set; }
        
        [Index(9)]
        public virtual int firstHeadShape { get; set; }

        [Index(10)]
        public virtual int secondHeadShape { get; set; }
        
        [Index(11)]
        public virtual int firstSkinTone { get; set; }

        [Index(12)]
        public virtual int secondSkinTone { get; set; }
        
        [Index(13)]
        public virtual float headMix { get; set; }

        [Index(14)]
        public virtual float skinMix { get; set; }

        [Index(15)]
        public virtual int eyesColor { get; set; }
        
        [Index(16)]
        public virtual List<float> facefeature { get; set; }
        
        [Index(17)]
        public virtual Dictionary<int, string> headoverlay { get; set; }
    }
    */
    [JsonObject]
    public class Body
    {
        public Body() { }

        public void SetDefault()
        {
            ShapeFirst = 0;
            ShapeSecond = 0;
            ShapeThird = 0;
            ShapeMix = 0;
            SkinFirst = 0;
            SkinSecond = 0;
            SkinThird = 0;
            skinMix = 0;
            firstHeadShape = 0;
            secondHeadShape = 0;
            firstSkinTone = 0;
            secondSkinTone = 0;
            headMix = 0;
            skinMix = 0;
            eyesColor = 0;
            overlayHair = 0;
            facefeature = new List<float>();
            headOverlay = new List<List<float>>();
            decoration = new List<int>();
            facialDecoration = new List<int>();
        }
        
        public virtual byte ShapeFirst { get; set; }
        public virtual byte ShapeSecond { get; set; }
        public virtual byte ShapeThird { get; set; }
        public virtual byte SkinFirst { get; set; }
        public virtual byte SkinSecond { get; set; }
        public virtual byte SkinThird { get; set; }
        public virtual float ShapeMix { get; set; }
        public virtual float SkinMix { get; set; }
        public virtual float ThirdMix { get; set; }
        public virtual int firstHeadShape { get; set; }
        public virtual int secondHeadShape { get; set; }
        public virtual int firstSkinTone { get; set; }
        public virtual int secondSkinTone { get; set; }
        public virtual int overlayHair { get; set; }

        public virtual float headMix { get; set; }
        public virtual float skinMix { get; set; }
        public virtual int eyesColor { get; set; }
        public virtual List<float> facefeature { get; set; }
        public virtual List<List<float>> headOverlay { get; set; }
        public virtual List<int> decoration { get; set; }
        public virtual List<int> facialDecoration { get; set; }

    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*
    [ZeroFormattable]
    public class IdCharacter {

        public IdCharacter() { }

        public void SetDefault() {
            Random rand = new Random();
            name = "";
            birthday = "";
            last_name = "";
            date_issue = "";
            date_expiration = "";
            path_profil = "";
            nationality = "";
            place_of_birth = "";
            height = 185;
            sex = rand.Next(0, 1);
        }
        
        [Index(0)]
        public virtual string name { get; set; }

        [Index(1)]
        public virtual string birthday { get; set; }

        [Index(2)]
        public virtual string last_name { get; set; }

        [Index(3)]
        public virtual string date_issue { get; set; }

        [Index(4)]
        public virtual string date_expiration { get; set; }

        [Index(5)]
        public virtual string path_profil { get; set; }

        [Index(6)]
        public virtual string nationality { get; set; }

        [Index(7)]
        public virtual string place_of_birth { get; set; }

        [Index(8)]
        public virtual float height { get; set; }

        [Index(9)]
        public virtual int age { get; set; }

        [Index(10)]
        public virtual int sex { get; set; }
    }
    */

    [JsonObject]
    public class IdCharacter
    {

        public IdCharacter() { }

        public void SetDefault()
        {
            Random rand = new Random();
            name = "";
            birthday = "";
            last_name = "";
            date_issue = "";
            date_expiration = "";
            path_profil = "";
            nationality = "";
            place_of_birth = "";
            height = 185;
            sex = rand.Next(0, 1);
        }
        
        public virtual string name { get; set; }
        public virtual string birthday { get; set; }
        public virtual string last_name { get; set; }
        public virtual string date_issue { get; set; }
        public virtual string date_expiration { get; set; }
        public virtual string path_profil { get; set; }
        public virtual string nationality { get; set; }
        public virtual string place_of_birth { get; set; }
        public virtual float height { get; set; }
        public virtual int age { get; set; }
        public virtual int sex { get; set; }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*[ZeroFormattable]
    public class Users {
        public Users() { }

        public void SetDefault() {
            social = "";
            password = "";
            permission = 0;
            dimension = 0;
            dimension_vocal = 0;
            cuff = false;
            service = false;
            jobs = "Check";
            permission_jobs = new Dictionary<string, int>();
            service_jobs = new Dictionary<string, bool>();
        }
        
        [Index(0)]
        public virtual string social { get; set; }

        [Index(1)]
        public virtual string password { get; set; }

        [Index(2)]
        public virtual int permission { get; set; }

        [Index(3)]
        public virtual uint dimension { get; set; }

        [Index(4)]
        public virtual float dimension_vocal { get; set; }

        [Index(5)]
        public virtual bool cuff { get; set; }

        [Index(6)]
        public virtual bool service { get; set; }

        [Index(7)]
        public virtual string jobs { get; set; }

        [Index(8)]
        public virtual Dictionary<string, int> permission_jobs { get; set; }
        
        [Index(9)]
        public virtual Dictionary<string, bool> service_jobs { get; set; }
    }*/


    [JsonObject]
    public class Users
    {
        public Users() { }

        public void SetDefault()
        {
            ts_name = "";
            social = "";
            address = "";
            password = "";
            permission = 0;
            dimension = 0;
            dimension_vocal = 0;
            range_vocal = 50f;
            cuff = false;
            service = false;
            jobs = "Check";
            permission_jobs = new Dictionary<string, int>();
            service_jobs = new Dictionary<string, bool>();
            ticks = new List<long>();
            effect = new List<double>();
            active = new List<bool>();

            for (int i = 0; i < 10; i++) {
                active.Add(false);
                ticks.Add(0);
                effect.Add(3);
            }
        }

        public virtual string social { get; set; }
        public virtual string ts_name { get; set; }
        public virtual string password { get; set; }
        public virtual string address { get; set; }
        public virtual int permission { get; set; }
        public virtual uint dimension { get; set; }
        public virtual float dimension_vocal { get; set; }
        public virtual float range_vocal { get; set; }
        public virtual bool cuff { get; set; }
        public virtual bool service { get; set; }
        public virtual string jobs { get; set; }
        public virtual List<long> ticks { get; set; }
        public virtual List<bool> active { get; set; }
        public virtual List<double> effect { get; set; }

        public virtual Dictionary<string, int> permission_jobs { get; set; }
        public virtual Dictionary<string, bool> service_jobs { get; set; }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>


    /*[ZeroFormattable]
    public class Information
    {
        public Information() { }

        public void SetDefault() {
            ActualMoney = 1500;
            Hunger = 100;
            Water = 100;
            Alcool = 0;
            Position = new Vector3(0, 0, 0);
        }
        
        [Index(0)]
        public virtual float ActualMoney { get; set; }

        [Index(1)]
        public virtual float Hunger { get; set; }

        [Index(2)]
        public virtual float Water { get; set; }

        [Index(3)]
        public virtual float Alcool { get; set; }

        [Index(4)]
        public virtual Vector3 Position { get; set; }
    }*/



    [JsonObject]
    public class Information
    {
        public Information() { }

        public void SetDefault()
        {
            ActualMoney = 1500;
            Hunger = 100;
            Water = 100;
            Alcool = 0;
            Position = new Vector3(0, 0, 0);
        }
        
        public virtual float ActualMoney { get; set; }
        public virtual float Hunger { get; set; }
        public virtual float Water { get; set; }
        public virtual float Alcool { get; set; }
        public virtual Vector3 Position { get; set; }
    }

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>
    /// 

    /// <summary>
    /// ////////////////////////////////////////////////////////////
    /// </summary>

    /*[ZeroFormattable]
    public class DataUser
    {
        [Index(0)]
        public virtual Users user { get; set; }
        [Index(1)]
        public virtual Information information { get; set; }
        [Index(2)]
        public virtual Cloth cloth { get; set; }
        [Index(3)]
        public virtual Body body { get; set; }
        [Index(4)]
        public virtual RigidBody rigidbody { get; set; }
        [Index(5)]
        public virtual IdCharacter id_card { get; set; }
        [Index(6)]
        public virtual Animation anim { get; set; }
        [Index(7)]
        public virtual Scene scene { get; set; }
        //[Index(8)]
        //public virtual Synchronization.VehiclesDatas vehiculesDatas { get; set; }
        [Index(8)]
        public virtual PlayerInventory inventory { get; set; }
        [Index(9)]
        public virtual Attach attach { get; set; }


        public byte[] SerializeObject()
        {
            return FAPI.SerializeObject<DataUser>(this);
        }
        
        public void DeserializeObjectAndSet(ref DataUser data, byte[] buffer)
        {
            data = FAPI.DeserializeObject<DataUser>(buffer);
        }

        public DataUser()
        {
            user = new Users();
            user.SetDefault();
            information = new Information();
            information.SetDefault();
            id_card = new IdCharacter();
            id_card.SetDefault();
            cloth = new Cloth();
            cloth.SetDefault(id_card.sex);
            body = new Body();
            body.SetDefault();
            rigidbody = new RigidBody();
            rigidbody.SetDefault();
            anim = new Animation();
            anim.SetDefault();
            scene = new Scene();
            scene.SetDefault();
            inventory = new PlayerInventory();
            attach = new Attach();
            attach.SetDefault();
        }
    }*/


    [JsonObject]
    public class DataUser
    {
        public virtual Users user { get; set; }
        public virtual Information information { get; set; }
        public virtual Cloth cloth { get; set; }
        public virtual Body body { get; set; }
        public virtual RigidBody rigidbody { get; set; }
        public virtual IdCharacter id_card { get; set; }
        public virtual Animation anim { get; set; }
        public virtual Scene scene { get; set; }
        //[Index(8)]
        //public virtual Synchronization.VehiclesDatas vehiculesDatas { get; set; }
        public virtual PlayerInventory inventory { get; set; }
        public virtual List<Attach> attaches { get; set; }


        public byte[] SerializeObject()
        {
            return FAPI.SerializeObject<DataUser>(this);
        }


        public byte[] SerializeObjectZipJson()
        {
            return FAPI.SerializeObjectZipJson<DataUser>(this);
        }

        public string SerializeObjectJson()
        {
            return FAPI.SerializeObjectJson<DataUser>(this);
        }


        public void DeserializeObjectAndSet(ref DataUser data, byte[] buffer)
        {
            data = FAPI.DeserializeObject<DataUser>(buffer);
        }

        public DataUser()
        {
            user = new Users();
            user.SetDefault();
            information = new Information();
            information.SetDefault();
            id_card = new IdCharacter();
            id_card.SetDefault();
            cloth = new Cloth();
            cloth.SetDefault(id_card.sex);
            body = new Body();
            body.SetDefault();
            rigidbody = new RigidBody();
            rigidbody.SetDefault();
            anim = new Animation();
            anim.SetDefault();
            scene = new Scene();
            scene.SetDefault();
            inventory = new PlayerInventory();
            inventory.SetClothListbyData(this);
            attaches = new List<Attach>();
            Attach attach = new Attach();
            attach.SetDefault();
            attaches.Add(attach);
        }
    }
}
