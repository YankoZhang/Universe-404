using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace UnityEditor.Rendering.Universal
{
    [VolumeComponentEditor(typeof(HologramBlock))]
    sealed class HologramBlockEditor : VolumeComponentEditor
    {
        SerializedDataParameter m_enableEffect;
        SerializedDataParameter m_scanLineJitter;
        SerializedDataParameter m_colorDrift;
        SerializedDataParameter m_speed;
        SerializedDataParameter m_blockSize;

        public override void OnEnable()
        {
            var o = new PropertyFetcher<HologramBlock>(serializedObject);

            m_scanLineJitter = Unpack(o.Find(x => x.scanLineJitter));
            m_colorDrift = Unpack(o.Find(x => x.colorDrift));
            m_speed = Unpack(o.Find(x => x.speed));
            m_blockSize = Unpack(o.Find(x => x.blockSize));
            m_enableEffect = Unpack(o.Find(x => x.enableEffect));
        }

        //public override void OnDisable()
        //{
        //    var o = new PropertyFetcher<HologramBlock>(serializedObject);
        //    m_enableEffect = Unpack(o.Find(x => x.enableEffect));
        //    HologramBlock.en.value = false;
        //}
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("ȫϢЧ������Ƶ����Ч��", EditorStyles.largeLabel);
            EditorGUILayout.LabelField("�����ֶ����û��Ƴ���Ч��������ᴦ��", EditorStyles.miniLabel);
            EditorGUILayout.LabelField("Ҫ��ѡEnable Effect������Ч����������л������ر�Ч����", EditorStyles.miniLabel);
            PropertyField(m_enableEffect);
            PropertyField(m_scanLineJitter);
            PropertyField(m_colorDrift);
            PropertyField(m_speed);
            PropertyField(m_blockSize);
        }
    }
}
