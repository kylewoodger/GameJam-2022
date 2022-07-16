 Shader "Example/Diffuse Texture" {
    Properties {
      _MainTex ("Texture", 2D) = "white" {}
        _AreaColor ("Area Color", Color) = (0, 0, 0) 
        _Center ("Center", Vector) = (0, 0, 0, 0)
        _Radius ("Radius", Range(0, 500)) = 75
        _Border ("Border", Range(0, 100)) = 12
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      
      fixed _AreaColor;
      float3 _Center;
      float _Radius;
      sampler2D _MainTex;
      float _Border;
      
      struct Input {
            float2 uv_MainTex;
            float3 worldPos;
      };

      void surf (Input IN, inout SurfaceOutput o) {
          half4 c = tex2D (_MainTex, IN.uv_MainTex); 
           float dist = distance(_Center, IN.worldPos);
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      if (dist > _Radius && dist < (_Radius + _Border))
           {
               o.Albedo = _AreaColor;
           } 
           o.Alpha = c.a;
      }
      
      ENDCG
    } 
    Fallback "Diffuse"
  }