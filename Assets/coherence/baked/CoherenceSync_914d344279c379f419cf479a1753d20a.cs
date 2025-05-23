// Copyright (c) coherence ApS.
// For all coherence generated code, the coherence SDK license terms apply. See the license file in the coherence Package root folder for more information.

// <auto-generated>
// Generated file. DO NOT EDIT!
// </auto-generated>
namespace Coherence.Generated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Coherence.Toolkit;
    using Coherence.Toolkit.Bindings;
    using Coherence.Entities;
    using Coherence.ProtocolDef;
    using Coherence.Brook;
    using Coherence.Toolkit.Bindings.ValueBindings;
    using Coherence.Toolkit.Bindings.TransformBindings;
    using Coherence.Connection;
    using Coherence.SimulationFrame;
    using Coherence.Interpolation;
    using Coherence.Log;
    using Logger = Coherence.Log.Logger;
    using UnityEngine.Scripting;
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_fc42a921d8734179887bcfee71a14a34 : PositionBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldPosition);
        public override string CoherenceComponentName => "WorldPosition";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(coherenceSync.coherencePosition); }
            set { coherenceSync.coherencePosition = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldPosition)coherenceComponent).value;
            if (!coherenceSync.HasParentWithCoherenceSync) { value += floatingOriginDelta; }

            var simFrame = ((WorldPosition)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldPosition)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldPosition();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_e04e3be40f164006b192de583edfb3d8 : RotationBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(WorldOrientation);
        public override string CoherenceComponentName => "WorldOrientation";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Quaternion Value
        {
            get { return (UnityEngine.Quaternion)(coherenceSync.coherenceRotation); }
            set { coherenceSync.coherenceRotation = (UnityEngine.Quaternion)(value); }
        }

        protected override (UnityEngine.Quaternion value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((WorldOrientation)coherenceComponent).value;

            var simFrame = ((WorldOrientation)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (WorldOrientation)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new WorldOrientation();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_5d12343ffcb644d5a7434adf3897ce37 : ScaleBinding
    {   
        private global::UnityEngine.Transform CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Transform)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(GenericScale);
        public override string CoherenceComponentName => "GenericScale";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override UnityEngine.Vector3 Value
        {
            get { return (UnityEngine.Vector3)(coherenceSync.coherenceLocalScale); }
            set { coherenceSync.coherenceLocalScale = (UnityEngine.Vector3)(value); }
        }

        protected override (UnityEngine.Vector3 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((GenericScale)coherenceComponent).value;

            var simFrame = ((GenericScale)coherenceComponent).valueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (GenericScale)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.value = Value;
            }
            else
            {
                update.value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.valueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new GenericScale();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_61ce2ea1654c4b99a48c76a876e2318d : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000000001;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Forward_32_Input;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Forward_32_InputSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Forward_32_Input = Value;
            }
            else
            {
                update.Forward_32_Input = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Forward_32_InputSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_5c3d0625314d4b6a84b3e6e4324194f5 : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000000010;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Horizontal_32_Input;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Horizontal_32_InputSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Horizontal_32_Input = Value;
            }
            else
            {
                update.Horizontal_32_Input = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Horizontal_32_InputSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_08c34b5561d64d378feeeef208a88b3f : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000000100;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Yaw_32_Input;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Yaw_32_InputSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Yaw_32_Input = Value;
            }
            else
            {
                update.Yaw_32_Input = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Yaw_32_InputSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_da7cd4edb1644e999be5ef51dac42db1 : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000001000;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Float_32_Value;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Float_32_ValueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Float_32_Value = Value;
            }
            else
            {
                update.Float_32_Value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Float_32_ValueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_9f73f41399214d92a6a5fbea470eff49 : IntAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000010000;

        public override System.Int32 Value
        {
            get { return (System.Int32)(CastedUnityComponent.GetInteger(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetInteger(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Int32 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Int_32_Value;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Int_32_ValueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Int_32_Value = Value;
            }
            else
            {
                update.Int_32_Value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Int_32_ValueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_d73494854c04483d9aaf18e6f00ac842 : BoolAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000000100000;

        public override System.Boolean Value
        {
            get { return (System.Boolean)(CastedUnityComponent.GetBool(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetBool(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Boolean value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Bool_32_Value;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Bool_32_ValueSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Bool_32_Value = Value;
            }
            else
            {
                update.Bool_32_Value = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Bool_32_ValueSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_2007f2da1ea747c18ff9bc49f37e7b1a : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000001000000;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Force;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).ForceSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Force = Value;
            }
            else
            {
                update.Force = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.ForceSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_5b2ced359def414fa48d56a423e0a6f5 : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000010000000;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Leg;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).LegSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Leg = Value;
            }
            else
            {
                update.Leg = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.LegSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_5af9eaec46034571ab2ebd0952bc310f : IntAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000000100000000;

        public override System.Int32 Value
        {
            get { return (System.Int32)(CastedUnityComponent.GetInteger(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetInteger(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Int32 value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Item_32_ID;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Item_32_IDSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Item_32_ID = Value;
            }
            else
            {
                update.Item_32_ID = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Item_32_IDSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_6aefa3d41754496982de16976802528d : BoolAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000001000000000;

        public override System.Boolean Value
        {
            get { return (System.Boolean)(CastedUnityComponent.GetBool(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetBool(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Boolean value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Moving;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).MovingSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Moving = Value;
            }
            else
            {
                update.Moving = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.MovingSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_272ee1f8e498409ea15b815fdcab5e1f : BoolAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000010000000000;

        public override System.Boolean Value
        {
            get { return (System.Boolean)(CastedUnityComponent.GetBool(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetBool(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Boolean value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Item_32_Use;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Item_32_UseSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Item_32_Use = Value;
            }
            else
            {
                update.Item_32_Use = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Item_32_UseSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }
    [UnityEngine.Scripting.Preserve]
    public class Binding_914d344279c379f419cf479a1753d20a_26dfeb03a15e4fd3b0f0c71d7ce1fc0b : FloatAnimatorParameterBinding
    {   
        private global::UnityEngine.Animator CastedUnityComponent;

        protected override void OnBindingCloned()
        {
    	    CastedUnityComponent = (global::UnityEngine.Animator)UnityComponent;
        }

        public override global::System.Type CoherenceComponentType => typeof(_914d344279c379f419cf479a1753d20a_2829627674445409302);
        public override string CoherenceComponentName => "_914d344279c379f419cf479a1753d20a_2829627674445409302";
        public override uint FieldMask => 0b00000000000000000000100000000000;

        public override System.Single Value
        {
            get { return (System.Single)(CastedUnityComponent.GetFloat(CastedDescriptor.ParameterHash)); }
            set { CastedUnityComponent.SetFloat(CastedDescriptor.ParameterHash, value); }
        }

        protected override (System.Single value, AbsoluteSimulationFrame simFrame) ReadComponentData(ICoherenceComponentData coherenceComponent, Vector3 floatingOriginDelta)
        {
            var value = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Speed_32_Multiplier;

            var simFrame = ((_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent).Speed_32_MultiplierSimulationFrame;
            
            return (value, simFrame);
        }

        public override ICoherenceComponentData WriteComponentData(ICoherenceComponentData coherenceComponent, AbsoluteSimulationFrame simFrame)
        {
            var update = (_914d344279c379f419cf479a1753d20a_2829627674445409302)coherenceComponent;
            if (Interpolator.IsInterpolationNone)
            {
                update.Speed_32_Multiplier = Value;
            }
            else
            {
                update.Speed_32_Multiplier = GetInterpolatedAt(simFrame / InterpolationSettings.SimulationFramesPerSecond);
            }

            update.Speed_32_MultiplierSimulationFrame = simFrame;
            
            return update;
        }

        public override ICoherenceComponentData CreateComponentData()
        {
            return new _914d344279c379f419cf479a1753d20a_2829627674445409302();
        }    
    }

    [UnityEngine.Scripting.Preserve]
    public class CoherenceSync_914d344279c379f419cf479a1753d20a : CoherenceSyncBaked
    {
        private Entity entityId;
        private Logger logger = Coherence.Log.Log.GetLogger<CoherenceSync_914d344279c379f419cf479a1753d20a>();
        
        
        
        private IClient client;
        private CoherenceBridge bridge;
        
        private readonly Dictionary<string, Binding> bakedValueBindings = new Dictionary<string, Binding>()
        {
			["fc42a921d8734179887bcfee71a14a34"] = new Binding_914d344279c379f419cf479a1753d20a_fc42a921d8734179887bcfee71a14a34(),
			["e04e3be40f164006b192de583edfb3d8"] = new Binding_914d344279c379f419cf479a1753d20a_e04e3be40f164006b192de583edfb3d8(),
			["5d12343ffcb644d5a7434adf3897ce37"] = new Binding_914d344279c379f419cf479a1753d20a_5d12343ffcb644d5a7434adf3897ce37(),
			["61ce2ea1654c4b99a48c76a876e2318d"] = new Binding_914d344279c379f419cf479a1753d20a_61ce2ea1654c4b99a48c76a876e2318d(),
			["5c3d0625314d4b6a84b3e6e4324194f5"] = new Binding_914d344279c379f419cf479a1753d20a_5c3d0625314d4b6a84b3e6e4324194f5(),
			["08c34b5561d64d378feeeef208a88b3f"] = new Binding_914d344279c379f419cf479a1753d20a_08c34b5561d64d378feeeef208a88b3f(),
			["da7cd4edb1644e999be5ef51dac42db1"] = new Binding_914d344279c379f419cf479a1753d20a_da7cd4edb1644e999be5ef51dac42db1(),
			["9f73f41399214d92a6a5fbea470eff49"] = new Binding_914d344279c379f419cf479a1753d20a_9f73f41399214d92a6a5fbea470eff49(),
			["d73494854c04483d9aaf18e6f00ac842"] = new Binding_914d344279c379f419cf479a1753d20a_d73494854c04483d9aaf18e6f00ac842(),
			["2007f2da1ea747c18ff9bc49f37e7b1a"] = new Binding_914d344279c379f419cf479a1753d20a_2007f2da1ea747c18ff9bc49f37e7b1a(),
			["5b2ced359def414fa48d56a423e0a6f5"] = new Binding_914d344279c379f419cf479a1753d20a_5b2ced359def414fa48d56a423e0a6f5(),
			["5af9eaec46034571ab2ebd0952bc310f"] = new Binding_914d344279c379f419cf479a1753d20a_5af9eaec46034571ab2ebd0952bc310f(),
			["6aefa3d41754496982de16976802528d"] = new Binding_914d344279c379f419cf479a1753d20a_6aefa3d41754496982de16976802528d(),
			["272ee1f8e498409ea15b815fdcab5e1f"] = new Binding_914d344279c379f419cf479a1753d20a_272ee1f8e498409ea15b815fdcab5e1f(),
			["26dfeb03a15e4fd3b0f0c71d7ce1fc0b"] = new Binding_914d344279c379f419cf479a1753d20a_26dfeb03a15e4fd3b0f0c71d7ce1fc0b(),
        };
        
        private Dictionary<string, Action<CommandBinding, CommandsHandler>> bakedCommandBindings = new Dictionary<string, Action<CommandBinding, CommandsHandler>>();
        
        public CoherenceSync_914d344279c379f419cf479a1753d20a()
        {
        }
        
        public override Binding BakeValueBinding(Binding valueBinding)
        {
            if (bakedValueBindings.TryGetValue(valueBinding.guid, out var bakedBinding))
            {
                valueBinding.CloneTo(bakedBinding);
                return bakedBinding;
            }
            
            return null;
        }
        
        public override void BakeCommandBinding(CommandBinding commandBinding, CommandsHandler commandsHandler)
        {
            if (bakedCommandBindings.TryGetValue(commandBinding.guid, out var commandBindingBaker))
            {
                commandBindingBaker.Invoke(commandBinding, commandsHandler);
            }
        }
        
        public override void ReceiveCommand(IEntityCommand command)
        {
            switch (command)
            {
                default:
                    logger.Warning(Coherence.Log.Warning.ToolkitBakedSyncReceiveCommandUnhandled,
                        $"CoherenceSync_914d344279c379f419cf479a1753d20a Unhandled command: {command.GetType()}.");
                    break;
            }
        }
        
        public override void CreateEntity(bool usesLodsAtRuntime, string archetypeName, AbsoluteSimulationFrame simFrame, List<ICoherenceComponentData> components)
        {

            if (!usesLodsAtRuntime)
            {
                return;
            }
            
            if (Archetypes.IndexForName.TryGetValue(archetypeName, out int archetypeIndex))
            {
                components.Add(new ArchetypeComponent
                    {
                        index = archetypeIndex,
                        indexSimulationFrame = simFrame,
                        FieldsMask = 0b1
                    }
                );

                return;                
            }
    
            logger.Warning(Coherence.Log.Warning.ToolkitBakedSyncCreateEntityMissingArchetype,
                $"Unable to find archetype {archetypeName} in dictionary. Please, bake manually (coherence > Bake)");
        }
        
        public override void Dispose()
        {
        }
        
        public override void Initialize(Entity entityId, CoherenceBridge bridge, IClient client, CoherenceInput input, Logger logger)
        {
            this.logger = logger.With<CoherenceSync_914d344279c379f419cf479a1753d20a>();
            this.bridge = bridge;
            this.entityId = entityId;
            this.client = client;        
        }
    }
}
