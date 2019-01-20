Shader "it-sure-is-cold-out-here/Outline Unlit" {
	Properties {
	    _MainTex ("Base (RGB)", 2D) = "white" {}
		_OutlineExtrusion("Outline Extrusion", float) = 0
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineDot("Outline Dot", float) = 0.25
	}

	SubShader {
	    Tags { "RenderType"="Opaque" }
	    LOD 100

	    Pass {
	        CGPROGRAM
	            #pragma vertex vert
	            #pragma fragment frag
	            #pragma target 2.0
	            #pragma multi_compile_fog

	            #include "UnityCG.cginc"

	            struct appdata_t {
	                float4 vertex : POSITION;
	                float2 texcoord : TEXCOORD0;
	                UNITY_VERTEX_INPUT_INSTANCE_ID
	            };

	            struct v2fa {
	                float4 vertex : SV_POSITION;
	                float2 texcoord : TEXCOORD0;
	                UNITY_FOG_COORDS(1)
	                UNITY_VERTEX_OUTPUT_STEREO
	            };

	            sampler2D _MainTex;
	            float4 _MainTex_ST;

	            v2fa vert (appdata_t v)
	            {
	                v2fa o;
	                UNITY_SETUP_INSTANCE_ID(v);
	                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	                o.vertex = UnityObjectToClipPos(v.vertex);
	                o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
	                UNITY_TRANSFER_FOG(o,o.vertex);
	                return o;
	            }

	            fixed4 frag (v2fa i) : SV_Target
	            {
	                fixed4 col = tex2D(_MainTex, i.texcoord);
	                UNITY_APPLY_FOG(i.fogCoord, col);
	                UNITY_OPAQUE_ALPHA(col.a);
	                return col;
	            }
	        ENDCG
	    }

		// Outline pass
		Pass {

			Name "OUTLINE"
			Tags { "LightMode" = "Always" }
			Cull Front
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha
			//Offset 50,50

			CGINCLUDE
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2fb {
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			uniform float _OutlineExtrusion;
			uniform float4 _OutlineColor;

			v2fb vert(appdata v) {
				// just make a copy of incoming vertex data but scaled according to normal direction
				v2fb o;

				float4 newPos = v.vertex;

				// normal extrusion technique
				float3 normal = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
				newPos += float4(normal, 0.0) * _OutlineExtrusion;

				// convert to world space
				o.pos = UnityObjectToClipPos(newPos);

				o.color = _OutlineColor;
				return o;
			}
			ENDCG

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			half4 frag(v2fb i) :COLOR { return i.color; }
			ENDCG
		}
	}
}
