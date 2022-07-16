Shader "Custom/CircleOnTerrain"
{
    Properties
    {
        _MainText ("Texture", 2D) = "white" {}
        _AreaColor ("Area Color", Color) = (0, 0, 0) 
        _Center ("Center", Vector) = (0, 0, 0, 0)
        _Radius ("Radius", Range(0, 500)) = 75
        _Border ("Border", Range(0, 100)) = 12
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        fixed _AreaColor;
        float3 _Center;
        float _Radius;
        float _Border;

        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };


        void surf (Input IN, inout SurfaceOutput o)
        {
           half4 c = tex2D (_MainTex, IN.uv_MainTex); 
           float dist = distance(_Center, IN.worldPos);

           if (dist > _Radius && dist < (_Radius + _Border))
           {
               o.Albedo = _AreaColor;
           } 
           o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
