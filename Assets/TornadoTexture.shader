﻿Shader "Custom/TornadoTexture"
{
	 Properties
	 {
		 _MainTex("Texture", 2D) = "white" {}
		 _SubTex1("Subtexture1", 2D) = "white" {}
		 _SubTex2("Subtexture2", 2D) = "white" {}
	 }
		  SubShader
	 {
		 Tags { "RenderType" = "Opaque" }
		 LOD 100

		 Pass
		 {
			 CGPROGRAM
			 #pragma vertex vert
			 #pragma fragment frag

			 #include "UnityCG.cginc"

			 struct appdata
			 {
				 float4 vertex : POSITION;
				 float2 uv : TEXCOORD0;
			 };

			 struct v2f
			 {
				 float2 uv : TEXCOORD0;
				 float4 vertex : SV_POSITION;
			 };

			 sampler2D _MainTex, _SubTex1, _SubTex2;
			 float4 _MainTex_ST;

			 v2f vert(appdata v)
			 {
				 v2f o;
				 o.vertex = UnityObjectToClipPos(v.vertex);
				 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				 return o;
			 }

			 fixed4 frag(v2f i) : SV_Target
			 {
				 half4 sub;
				 half2 uv = i.uv;
				 half t = _Time.x - floor(_Time.x);
				 uv.x = i.uv.x + t;
				 fixed4 col = tex2D(_MainTex, uv);

				 uv.x = i.uv.x + t * 2;
				 sub = tex2D(_SubTex1, uv);
			 col.rgb = lerp(col.rgb, sub.rgb, sub.a);

				 uv.x = i.uv.x + t * 4;
				 sub = tex2D(_SubTex2, uv);
			 col.rgb = lerp(col.rgb, sub.rgb, sub.a);

				 return col;
			 }
			 ENDCG
		 }
	 }
}
