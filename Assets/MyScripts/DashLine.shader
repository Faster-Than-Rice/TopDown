Shader "Unlit/DashLine"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Rate ("Rate", Range(0, 1)) = 0.5
        _DivisionNumber ("Division", Range(0, 100)) = 10
    }
    SubShader
    {
        // �j�������͓��߂��K�v�Ȃ��� Transparent �� AlphaBlend ��ݒ�
        Tags { "RenderType"="Transparent" "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _Rate;
            int _DivisionNumber;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // UV�}�b�v��X���̈ʒu�ɉ����ĐF�̕\��/��\����؂�ւ���
                // step:�����������������傫���ꍇ�� 1 ���������ꍇ�� 0 ��Ԃ�
                // frac:�������̏����l���擾����
                return step(_Rate, frac(i.uv.x * _DivisionNumber)) * _Color;
            }
            ENDCG
        }
    }
}