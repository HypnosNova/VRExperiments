varying float inBounds;
varying float xPosition;
varying float yPosition;

attribute vec2 bounds;
attribute vec3 color;
attribute float opacity;

varying vec3 vColor;
varying vec3 vNormal;

uniform float playhead;

void main() {

    // world position
    vec4 worldPosition = projectionMatrix * modelMatrix * vec4(position, 1.0);
    xPosition = worldPosition.x / 320.0;
    yPosition = worldPosition.y;

    vColor = color;
    vNormal = normal;

    if (bounds.x <= playhead && playhead <= bounds.y) {
        inBounds = 1.0;
    } else { 
        inBounds = 0.0;
    }

    gl_Position = projectionMatrix *
                modelViewMatrix *
                vec4(position.x, 
                     position.y, 
                     position.z, 1.0);
}
