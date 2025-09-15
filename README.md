# Unity FPS Controller (New Input System)

This project implements a simple **First Person Controller** in Unity using the **New Input System**.  
It supports **movement, looking around, jumping, crouching, and sprinting**.

---

## 🎮 Features
- ✅ **WASD movement** (with adjustable speed).  
- ✅ **Mouse look** (yaw & pitch, clamped).  
- ✅ **Jumping** (with customizable jump height).  
- ✅ **Crouching** (toggle crouch, scales the player).  
- ✅ **Sprinting** (hold Shift to move faster).  
- ✅ Uses **CharacterController** for smooth collisions and gravity.  
- ✅ Cursor lock (FPS style).  

---

## ⚙️ Setup Instructions

### 1. Add Components
1. Create a **Capsule** in Unity (`GameObject → 3D Object → Capsule`).
2. Add a **CharacterController** component to the Capsule.
   - Height = `2`
   - Center = `(0, 1, 0)`
3. Add a **Camera** as a **child of the Capsule**.
   - Position it at head height (`Y ≈ 0.9`).
   - Assign this Camera to the `playerCamera` field in the script.

---

### 2. Input Actions
Create an **Input Actions** asset with the following bindings:

| Action   | Type   | Binding(s)                 |
|----------|--------|----------------------------|
| `move`   | Value (Vector2) | `WASD` (2D Composite) |
| `look`   | Value (Vector2) | `Mouse Delta` |
| `jump`   | Button | `Space` |
| `crouch` | Button | `C` |
| `sprint` | Button | `Left Shift` |

Assign these actions to the `MovementManager` script in the Inspector.

---

### 3. Script Usage
- Attach `MovementManager.cs` to your **Capsule**.
- Drag the **Camera** into the `playerCamera` field.
- Adjust the movement, look, crouch, and sprint settings in the Inspector.

---

## 🕹️ Controls
- **WASD** → Move
- **Mouse** → Look around
- **Space** → Jump
- **C** → Toggle crouch
- **Shift** → Sprint

---

## 📌 Notes
- Crouching is implemented by scaling the player’s transform.  
- You can switch to adjusting **CharacterController height** if you want more precise collision handling.  
- Sprinting cancels automatically when crouching (by speed override logic).  

---

## 🛠️ Requirements
- Unity **2021.3 LTS** or later
- **Input System package** (`com.unity.inputsystem`)

---

## 🚀 Future Improvements
- Smooth crouch transitions
- Head bobbing
- Stamina system for sprint
- Interaction system (doors, items, etc.)

---
