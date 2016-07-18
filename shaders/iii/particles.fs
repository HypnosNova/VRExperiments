uniform sampler2D map;
varying vec3 vColor;

void main() {
    
    gl_FragColor = vec4( vColor, 1.0 ) * texture2D( map, vec2( gl_PointCoord.x, 1.0 - gl_PointCoord.y ) );

}