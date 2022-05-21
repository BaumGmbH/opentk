#version 450

layout(location = 0) out vec4 FragColor;

uniform sampler2D uTexture;

in vec2 vTextureCoordinates;

void main() {
	FragColor = texture(uTexture, vTextureCoordinates);
}