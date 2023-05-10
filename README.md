## Fruit-Monkey
### Semana 1
1. *Dia 1*
* Escenario de prueba creado con una esfera como personaje.
* Creacion del movimiento basico del personaje y la camara.
2. *Dia 2*
* Implementacion del salto.
3. *Dia 3*
* Implementada la primera pistola que instancia balas que aplican una fuerza con lo que colisiona.
4. *Dia 4*
* Cambiado el metodo de disparo, en vez de instanciar balas se utilizará Raycast, que tambien aplica una fuerza con lo que colisiona.
* Añadidas particulas en el arma y en la zona de impacto.
5. *Dia 5*
* Implementado el cuchillo y la posibilidad de cambiar de arma entre el cuchillo y la pistola.
6. *Dia 6*
* Intento de arreglar el Sway de las armas, ya que el Script que se encarga del movimiento de esta es eclipsado por el Animator controler y no funciona
* Implementacion del objeto granada
7. *Dia 7*
* Agregada a la granada la fuerza de explosion y sus particulas.
* Agregada la funcionalidad de trepar por los objetos escalables.
* Agregada la opcion de apuntar para tener una vision mas certera, ya que amplia el cambio de vision.
8. *Dia 8*
* Arreglado algunos errores a la hora de apuntar, como cuando pulsas apuntar y disparar a la vez se quedaba pillada el arma en la posicion de apuntado y ya no.
* Añadido un tiempo de recarga de la granada.
* Añadido ragdoll al modelo del enemigo.
* Añadida una IA para el enemigo.
9. *Dia 9*
* Añadido medidor de vida a los enemigos, dependiendo en que parte del cuerpo se golpee quite mas vida o menos. Cuando la vida llega a 0 se activa el ragdoll y se elimina el enemigo a los 45 segundos
10. *Dia 10*
* Añadida la fruta con su correspondiente animacion, el objeto de la fruta cambia su modelo de forma aleatoria
11. *Dia 11*
* Añadida a la fruta un efecto de particulas y se añadio la funcionalidad de poder ser cogida por el personaje
12. *Dia 12*
* Añadido el GameManager para gestionar cuantas frutas quedan por recoger y cada vez que recoges una se reduce
* Añadido una brujula que se mueve dependiendo donde este viendo el jugador, donde apareceran las frutas que faltan por recoger
* Añadido en la brujula las frutas que faltan por recoger y sus localizaciones
13. *Dia 13*
* Arreglado problema a la hora de coger las frutas y eliminarlas del array
* Añadida la funcionalidad del cuchillo
* Añadido un DeathFloor por si el jugador se sale del mapa que reaparezca arriba, y con ello añadida la vida y el poder perderla
* Añadido un temporizador del tiempo restante para utilizar la bomba
14. *Dia 14*
* Mejorada la mecanica del enemigo para que te pueda golpear mejor ya que a veces aunque el raycast chocara con el personaje no ocurria nada, tambien se añadieron mas raycast para una mejor captura del golpeo
* Añadida la animacion de golpeo al personaje
* Comienzo a crear el mapa del juego
15. *Dia 15*
* Creamos la mazmorra donde empezara el jugador y donde se explicaran los conceptos basicos del juego.
16. *Dia 16*
* Acabada la mazmorra donde empezara el jugador y donde se explicaran los conceptos basicos del juego.
17. *Dia 17*
* Mejorado el spawn para que si el jugador no esta cerca no genere mas enemigos y asi ahorrar recursos.
* Creacion de mapa