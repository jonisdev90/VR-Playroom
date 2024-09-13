# VR - Playroom

Este proyecto es una demostración de la implementación de un entorno de Realidad Virtual utilizando Unity para un prueba tecnica. Incluye características como la teleportación para el movimiento, una interfaz de usuario en VR para gestionar un inventario, y objetos interactivos con diversas funcionalidades.

## Requisitos

- Unity 2023.1.9f1 o posterior
- Unity XR Interaction Toolkit
- Unity New Input System
- Hardware VR compatible (por ejemplo, Oculus, HTC Vive)

## Controles

En este apartado vamos a detallar cuales son los controles para interactúar con la experiencia.

### Mando mano izquierda

- Botón de menu: Con este boton mostramos o ocultamos el inventario

### Mando mano derecha 

- Joystick: Moviendolo hacia arriba activamos el teletransporte y cuando lo soltamos nos desplazamos al lugar indicado. Moviendolo hacia los lados movemos la cámara en dicha direccion.
- Botón de grip: Se usa para interactúar con los elementos de la mesa, nos añaden elementos en el inventario.
- Botón trigger: Con el menu lo usamos para selecionar los elementos y con el arma para disparar la municion.
- Botón A: Lo usamos para cambiar de arma.
- Botón B: Lo usamos para recargar el arma cuando hay espacio en su cargador.

## Funcionalidades

### Sistema de Inventario:

- Pociones: Aumentan la barra de salud al usarse, hay dos tipos una pequeña y otra grande.
- Armas: Disminuyen la barra de salud del enemigo de prueba al dispararle.
- Munición: Sirve para recargar y poder usar las armas.
- Basura: Los objetos consumibles como son las posiones se convierten en basura, ocupando un espacio en el inventario.

### Barra de Salud:

La barra de salud se muestra sobre la parte superior del enemigo, dependiendo de la cantidad de daño recibida mostrará un color diferente acentuandomelas el peligro de muerte.

### Animaciones y Feedback:

Los objetos tiene tweens y sonido para mejorar el gamefeel.

## Ejecutar el Proyecto

1. Abre el proyecto en una versionéis compatible de Unity.
2. Compruébales tener todos los assets correctamente instalados.
3. Asegúrate de que tu headset VR esté correctamente configurado y conectado.
