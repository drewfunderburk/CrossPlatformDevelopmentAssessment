# Documentation

### Table of Contents

- [BallSpawnerBehaviour](#BallSpawnerBehaviour)
- [GameManagerBehaviour](#GameManagerBehaviour)
- [GoalBehaviour](#GoalBehaviour)
- [GoToNextSceneBehaviour](#GoToNextSceneBehaviour)
- [LineDrawBehaviour](#LineDrawBehaviour)
- [VictoryScreenBehaviour](#VictoryScreenBehaviour)
___

### BallSpawnerBehaviour
> Spawns balls on a timer, giving them an initial velocity and a lifetime

Variable | Use
:--------|:----
private GameObject _ballPrefab      | Holds a reference to the ball's prefab
private float _ballLifetime         | Specifies how long in seconds a ball should remain in the world before being destroyed
private float _spawnDelay           | Specifies the delay in seconds between ball spawns
private Vector2 _initialVelocity    | Specifies the initial velocity that balls should have when they are spawned
private float _spawnTimer           | Used to time ball spawns
___

### GameManagerBehaviour
> Manages global behaviour for scenes and handles scene transitions

Variable | Use
:--------|:----
public static [GameManagerBehaviour](#GameManagerBehaviour) Instance        | Singleton instance of this GameManagerBehaviour for use in other scripts
public static List<LineRenderer> Lines                                      | List of lines drawn to the scene
private [VictoryScreenBehaviour](#VictoryScreenBehaviour) _victoryScreen    | Reference to the victory screen so that it may be shown on game over
private [LineDrawbehaviour](#LineDrawbehaviour) _lineDraw                   | Reference to the player's LineDrawBehaviour so that it may be disabled on game over
private float _baseScore                                                    | Base score to be subtracted from
private bool _isGameOver                                                    | Whether or not the game is over

Properties |
:----------|
public bool IsGameOver |

Function | Parameters | Use
:--------|:-----------|:----
public void DoGameOver                      | N/A           | Perform all actions necessary to end the game
public float CalculateScore                 | N/A           | Calculate the player's score based on their line length
public void RestartScene                    | float delay   | Restarts the scene after a delay
private IEnumerator RestartSceneCoroutine   | float delay   | Coroutine used to restart the scene
public void QuitGame                        | N/A           | Quits the game
___

### GoalBehaviour
> Detects collisions from any object with the "Ball" tag and tells GameManagerBehaviour the game is over
___

### GoToNextSceneBehaviour
> Procedes to the next scene if left mouse button is pressed
___

### LineDrawBehaviour
> Allows the player to draw lines to the screen

Variable | Use
:--------|:----
private Material _material              | The material used to render the line
private Color _colorWhileDrawing        | The color to use while drawing the line
private Color _colorWhenFinished        | The color to use when drawing is complete
private float _lineWidth                | The thickness of the drawn line
private float _distanceBetweenPoints    | Distance to use when simplifying the line. A lower value will result in a more detailed line
private LineRenderer _lineRenderer      | Reference to the LineRenderer being used to draw the current line
private EdgeCollider2D _edgeCollider    | Reference to the EdgeCollider being used to handle the current line's collision
private GameObject _start               | GameObject used to hold the LineRenderer and EdgeCollider
private Vector2 _lastMousePosition      | The position of the mouse last frame
private Vector2 _startMousePosition     | The position of the mouse when the line was started

Function | Parameters | Use
:--------|:-----------|:----
private void DeleteLinesInArea  | Vector2 mousePosition | Allows the player to draw a box with the right mouse button, deleting all lines within it when the mouse is released
private void DrawLine           | Vector2 mousePosition | Allows the player to draw a line with the mouse
___

### VictoryScreenBehaviour
> Handles updating the score UI

Variable | Use
:--------|:----
private TextMeshProUGUI _scoreText  | Reference to the text object used for score

Function | Parameters | Use
:--------|:-----------|:----
public void UpdateScore | float score   | Updates the score text object with the given value
___

