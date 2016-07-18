varying float inBounds;
varying float xPosition;
varying float yPosition;
varying vec3 vColor;
varying float vOpacity;
varying vec3 vNormal;

vec3 rgb2hsv(vec3 c) {

    vec4 K = vec4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    vec4 p = mix(vec4(c.bg, K.wz), vec4(c.gb, K.xy), step(c.b, c.g));
    vec4 q = mix(vec4(p.xyw, c.r), vec4(c.r, p.yzx), step(p.x, c.r));

    float d = q.x - min(q.w, q.y);
    float e = 1.0e-10;
    return vec3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);

}

vec3 hsv2rgb(vec3 c) {
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

float lerp(float a, float b, float t) {
    return (a - b)*t + b;
}

void main() {
    

    vec3 hsv = rgb2hsv(vColor);
    vec3 n = vec3(vNormal);

    n /= 2.0;
    n += 0.5;

    hsv.x += xPosition / 1000.0;
    hsv.y = max(hsv.y, 0.7);
    hsv.z = max(hsv.z, 0.5);

    hsv.z += n.z / 2.0;
    hsv.x += n.x / 10.0;

    if (inBounds > 0.0) {
        
        if (xPosition < 0.0) {

            hsv.x = lerp(hsv.x, hsv.x+0.1, min(-xPosition, 1.0));
            vec3 c = hsv2rgb(hsv);
            c = max(c, c/(-xPosition*2.0));
            gl_FragColor = vec4(c, 1.0);

        } else {
            discard;
        }
        
    } else { 
    
        if (xPosition < 0.0) {
            gl_FragColor = vec4(hsv2rgb(hsv), -1.0/(0.02 * xPosition));
        } else { 
            discard;
        }
    }

    if (yPosition < -3000.0) {
        gl_FragColor = mix(gl_FragColor, vec4(0.09, 0.05, 0.19, 1.0), 0.75);
    }

}
