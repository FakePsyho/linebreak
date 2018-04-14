Shader "Background"
{
	Properties
	{
		_startColor("Start Color", Color) = (1,1,1,1)
		_endColor("End Color", Color) = (0,0,0,1)
		_startPoint("Start Point", Vector) = (1.0, 1.0, 0.0)
		_endPoint("End Point", Vector) = (0.0, 0.0, 0.0)
		_power("Power", Float) = 1
	}
	SubShader
	{
		Cull Off ZWrite On ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			fixed4 _startColor;
			fixed4 _endColor;
			float2 _startPoint;
			float2 _endPoint;
			float _power;

			v2f vert(appdata v) {
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {
				float px = _endPoint.x - _startPoint.x;
				float py = _endPoint.y - _startPoint.y;
				float d = px * px + py * py;
				float t = ((i.uv.x - _startPoint.x) * px + (i.uv.y - _startPoint.y) * py) / d;

				float4 col = lerp(_startColor, _endColor, pow(t, _power));
				return col;
			}
			ENDCG
		}
	}
}
