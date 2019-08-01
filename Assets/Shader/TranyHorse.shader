
Shader "Custom/TranyHorse" {
    
Properties {
    _NTex ("Normal", 2D) = "white" {}
    _ATex ("Angry", 2D) = "white" {}
    _FTex ("Furious", 2D) = "white" {}
    _Shift ("Shift", Range(0,2)) = 0
    _ClipVal ("Clip", Range(0,1)) = 0
        }

SubShader {

    Tags { "RenderType" = "Opaque" }
    LOD 150

    pass
    {
    CGPROGRAM
    #pragma vertex vert
    #pragma fragment frag
    #pragma target 2.0
    #include "UnityCG.cginc"

    sampler2D _NTex;
    sampler2D _ATex;
    sampler2D _FTex;
    fixed _Shift;
    fixed _ClipVal;
    
    struct v2f
    {
        half4 pos : SV_POSITION;
        half2 uv : TEXCOORD;
    };

    v2f vert(appdata_base v)
    {
        v2f o;
        o.pos = UnityObjectToClipPos(v.vertex);
        o.uv = v.texcoord;

        return o;
    }

    half4 frag(v2f IN) : COLOR
    {
        fixed4 col = 0;
        if(_Shift < 1)
        {
            col = lerp(tex2D(_NTex, IN.uv), tex2D(_ATex, IN.uv), _Shift);
        }else
        {
            col = lerp(tex2D(_ATex, IN.uv), tex2D(_FTex, IN.uv), _Shift - 1);
        }
        clip(col.a - _ClipVal);
        return col;
    }

    ENDCG
    }
}
Fallback "Mobile/VertexLit"
}

