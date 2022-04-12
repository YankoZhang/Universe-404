using System;

namespace UnityEngine.Rendering.Universal
{
    [System.Serializable, VolumeComponentMenu("HL/HologramBlock")]
    public sealed class HologramBlock : VolumeComponent, IPostProcessComponent
    {
        [Tooltip("�Ƿ���Ч��")]
        public BoolParameter enableEffect = new BoolParameter(true);

        [Range(0f,1f),Tooltip("ȫϢͶӰ��ɨ���߶���")]
        public FloatParameter scanLineJitter = new FloatParameter(0.17f);

        [Range(0f, 1f), Tooltip("ȫϢͶӰ��ɨ������ɫ����")]
        public FloatParameter colorDrift = new FloatParameter(0f);

        [Range(0f, 100f), Tooltip("ȫϢͶӰ�Ĵ�����Ƶ�ٶ�")]
        public FloatParameter speed = new FloatParameter(0f);

        [Range(0f, 100f), Tooltip("ȫϢͶӰ�Ĵ�����Ƶ�����С")]
        public FloatParameter blockSize = new FloatParameter(5f);

        public bool IsActive() => enableEffect==true;

        public bool IsTileCompatible() => false;
    }
}
