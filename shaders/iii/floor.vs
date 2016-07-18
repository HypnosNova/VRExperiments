// varying vec3 vWorldPosition;

// void main() {

//     vec4 worldPosition = modelMatrix * vec4( position, 1.0 );
//     vWorldPosition = worldPosition.xyz;

//     gl_Position = projectionMatrix * modelViewMatrix * vec4( position, 1.0 );

// }


varying vec3 vWorldPosition;
varying vec3 vWorldPosition2;
uniform float offset;
uniform float gridSize;


void main() {

    vec4 worldPosition = modelMatrix * vec4( position, 1.0 );
    vWorldPosition = worldPosition.xyz;

    vWorldPosition2 = (modelMatrix * 
    vec4( position.x + mod(offset, gridSize)
        , position.y
        , position.z, 1.0)).xyz;


    gl_Position = projectionMatrix * modelViewMatrix * 
    vec4( position.x + mod(offset, gridSize)
        , position.y
        , position.z
        , 1.0 
        );
}