
Shader "my/poartal_shader" {
	Properties
	{
		_power1("power1", Range(1 , 8)) = 8
		_spin("spin", Range(-5 , 5)) = 5
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
	_nuber_wawes("nuber _ wawes", Range(0 , 5)) = 1.098421
		_opacity("opacity", Range(0 , 1)) = 0.5058824
		[HideInInspector] _texcoord("", 2D) = "white" {}
	[HideInInspector] __dirty("", Int) = 1
	}

		SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		GrabPass{}
		CGPROGRAM
#include "UnityPBSLighting.cginc"
#include "UnityShaderVariables.cginc"
#pragma target 3.0
#pragma surface surf StandardCustomLighting keepalpha addshadow fullforwardshadows 
		struct Input
	{
		float4 screenPos;
		float2 uv_texcoord;
	};

	struct SurfaceOutputCustomLightingCustom
	{
		fixed3 Albedo;
		fixed3 Normal;
		half3 Emission;
		half Metallic;
		half Smoothness;
		half Occlusion;
		fixed Alpha;
		Input SurfInput;
		UnityGIInput GIData;
	};

	uniform sampler2D _GrabTexture;
	uniform sampler2D _TextureSample0;
	uniform float4 _TextureSample0_ST;
	uniform float _power1;
	uniform float _spin;
	uniform float _nuber_wawes;
	uniform float _opacity;


	inline float4 ASE_ComputeGrabScreenPos(float4 pos)
	{
#if UNITY_UV_STARTS_AT_TOP
		float scale = -1.0;
#else
		float scale = 1.0;
#endif
		float4 o = pos;
		o.y = pos.w * 0.5f;
		o.y = (pos.y - o.y) * _ProjectionParams.x * scale + o.y;
		return o;
	}


	inline half4 LightingStandardCustomLighting(inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi)
	{
		UnityGIInput data = s.GIData;
		Input i = s.SurfInput;
		half4 c = 0;
		float4 ase_screenPos = float4(i.screenPos.xyz , i.screenPos.w + 0.00000000001);
		float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos(ase_screenPos);
		float4 screenColor57 = tex2Dproj(_GrabTexture, UNITY_PROJ_COORD(ase_grabScreenPos));
		float2 uv_TextureSample0 = i.uv_texcoord * _TextureSample0_ST.xy + _TextureSample0_ST.zw;
		float cos56 = cos(0.5 * _Time.y);
		float sin56 = sin(0.5 * _Time.y);
		float2 rotator56 = mul(ase_screenPos.xy - float2(0.5,0.5) , float2x2(cos56 , -sin56 , sin56 , cos56)) + float2(0.5,0.5);
		float2 uv_TexCoord4 = i.uv_texcoord * float2(1,1) + float2(0,0);
		float2 temp_cast_2 = (0.5).xx;
		float clampResult34 = clamp((1.0 - length(abs(((uv_TexCoord4 - temp_cast_2) / 0.5)))) , 0.0 , 1.0);
		float cos23 = cos(((clampResult34 * _spin) + (frac((_Time.x * 0.4485896)) * 6.28318548202515)));
		float sin23 = sin(((clampResult34 * _spin) + (frac((_Time.x * 0.4485896)) * 6.28318548202515)));
		float2 rotator23 = mul(uv_TexCoord4 - float2(0.5,0.5) , float2x2(cos23 , -sin23 , sin23 , cos23)) + float2(0.5,0.5);
		float2 temp_cast_3 = (0.5).xx;
		float2 temp_output_5_0 = abs(((rotator23 - temp_cast_3) / 0.5));
		float clampResult25 = clamp(frac((atan2(length((temp_output_5_0).x) , length((temp_output_5_0).y)) * _nuber_wawes)) , 0.0 , 1.0);
		float clampResult50 = clamp((pow(clampResult34 , _power1) + (clampResult34 * (clampResult25 - _opacity))) , 0.0 , 1.0);
		float clampResult135 = clamp(_Time.x , 0.0 , 1.0);
		float4 lerpResult58 = lerp(screenColor57 , (tex2D(_TextureSample0, uv_TextureSample0) * float4(rotator56, 0.0 , 0.0)) , (clampResult50 * clampResult135));
		c.rgb = lerpResult58.rgb;
		c.a = 1;
		return c;
	}

	inline void LightingStandardCustomLighting_GI(inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi)
	{
		s.GIData = data;
	}

	void surf(Input i , inout SurfaceOutputCustomLightingCustom o)
	{
		o.SurfInput = i;
	}

	ENDCG
	}
		Fallback "Diffuse"
		
}