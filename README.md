Unity_Argon-Assult
==================   
[Udemy](https://www.udemy.com/ "Udemy.com Link") GameDev.tv Team의 [C#과 Unity로 3D게임 개발하기 : Argon Assult](https://www.udemy.com/course/best-3d-c-unity/learn/lecture/28433658?start=0#overview, "Argon Assult Lecture Link") 강의를 들으며 작성한 프로젝트입니다.   
학습 시작일 : 2022-07-10

# 핵심 학습 내용 요약
## Terrain
## Timeline
## 입력(구기능/신기능)
### 1. Input Manager(구기능)
* Edit/Project Setting/Input Manager에서 바인딩
* 입력값 전달(0 ~ 1 => sensitive에 의해 점차적인 증가)
```c++
xThrow = Input.GetAxis("Horizontal");
// Horizontal에 바인딩 된 키가 눌리면 입력값이 전달됨
```   
### 2. Input System(신기능)
* namespace 지정
```c++
using UnityEngine.InputSystem;
```
* 동작 생성 및 활성화/비활성화
``` c++
[SerializeField] InputAction movement;
// movement동작 생성 / 바인딩은 에디터 내 인스펙터 창에서
    
void OnEnable()
{
    movement.Enable();
}  //OnEnable에서 활성화해야 동작

void OnDisable()
{
    movement.Disable();
} //OnDisable에서 비활성화 필요
```
* 입력 값 전달 (0, 1 => 버튼이 눌리면 1, 안눌리면 0)
```c++
xThrow = movement.ReadValue<Vector2>().x;
//movement에 바인딩 된 키가 눌리면 입력값이 전달됨
``` 
### 3. 신기능과 구기능의 차이
* 신기능은 코드상에서 동작 추가 / 구기능은 프로젝트 세팅에서
* 신기능은 0, 1 이산적인 값 반환 / 구기능은 sensitive에 따라 0 ~ 1값 점차 증가 
* 2020.3.30f1버전 기준 구기능은 기본 탑제 / 신기능은 패키지 매니저를 통해 설치

## 로컬 좌표계
### 1. 월드 좌표계는 전체 월드 기준 / 로컬 좌표계는 부모 기준   
### 2. trasnform.localPosition
```c++
transform.localPosition = new Vector3(posX, posY, posZ);
```
### 3. transform.localRotation   
* Rotation을 변경하고자 하는 경우 회전이 원하는 대로 이루어지지 않을 가능성 있음.
* 따라서 Quaternion.Euler()함수를 사용하여 회전 제어
```c++
transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
```

## 최대/최소 범위 설정   
### 1. mathf.Clamp(변수, 최솟값, 최댓값)   
```c++
posX = Mathf.Clamp(posX, -xRange, xRange);
// 새로운 변수를 만들 필요 없이 기존 변수에 대입 가능
```
## 파티클 시스템 컴포넌트
### 1. 파티클 시스템은 게임 개체에 추가하는 컴포넌트
- 모듈 : 파티클의 움직임 제어