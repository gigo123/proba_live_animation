
Shader "my\dissolve1"
{
	Properties
	{

		_startTexture("startTexture", 2D) = "white" {}
		 __dirty("", Int) = 1
		_MaskClipValue("Mask Clip Value", Float) = 0.5
		_Albedo("Albedo", 2D) = "white" {}
	_Normal("Normal", 2D) = "bump" {}
	_DisolveGuide("Disolve Guide", 2D) = "white" {}
	_BurnRamp("Burn Ramp", 2D) = "white" {}
	_DissolveAmount("Dissolve Amount", Range(0 , 1)) = 0
		 _texcoord("", 2D) = "white" {}
	_efectActiv("efectActiv", Range(0 , 1)) = 0
	}

		SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+0" "IsEmissive" = "true" }
		Cull Off
		CGPROGRAM
#pragma target 3.0
#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
	{
		float2 uv_texcoord;
	};

	uniform sampler2D _Normal;
	uniform float4 _Normal_ST;
	uniform sampler2D _Albedo;
	uniform float4 _Albedo_ST;
	uniform float _DissolveAmount;
	uniform sampler2D _DisolveGuide;
	uniform float4 _DisolveGuide_ST;
	uniform sampler2D _BurnRamp;
	uniform float _MaskClipValue = 0.5;
	uniform sampler2D _startTexture;
	uniform float _efectActiv;

	void surf(Input i , inout SurfaceOutputStandard o)
	{
		if (_efectActiv < 0.1) {
			o.Albedo = tex2D(_startTexture, i.uv_texcoord).xyz;
			o.Alpha = 1;
			
		};
		if (_efectActiv > 0.1) {
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			o.Normal = tex2D(_Normal, uv_Normal).xyz;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			o.Albedo = tex2D(_Albedo, uv_Albedo).xyz;
			float2 uv_DisolveGuide = i.uv_texcoord * _DisolveGuide_ST.xy + _DisolveGuide_ST.zw;
			float float_1 = ((-0.6 + ((1.0 - _DissolveAmount) - 0.0) * (0.6 - -0.6) / (1.0 - 0.0)) + tex2D(_DisolveGuide, uv_DisolveGuide).r);
			float float_2 = (1.0 - clamp((-4.0 + (float_1 - 0.0) * (4.0 - -4.0) / (1.0 - 0.0)), 0.0, 1.0));
			float2 flaot2_1 = float2(float_2, 0);
			o.Emission = (float_2 * tex2D(_BurnRamp, flaot2_1)).xyz;
			o.Alpha = 1;
			clip(float_1 - _MaskClipValue);
		};

	}

	ENDCG
	}
		Fallback "Diffuse"

}
