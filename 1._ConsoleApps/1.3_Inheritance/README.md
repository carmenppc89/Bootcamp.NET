# 1.3 Inheritance

## Goal
Apply inheritance, abstract classes, polymorphism and constrained generics (`where T : ...`) across two different domains: a hospital system and a hierarchy of geometric shapes.

## Projects

| Project | Description |
|---|---|
| [Hospital](./CarmenPPerez_Hospital) | Manages the people in a hospital (doctors, patients, staff) through a class hierarchy |
| [2D Shapes](./CarmenPPerez_Forma2D) | Hierarchy of geometric shapes that compute their area through overridden abstract methods |

## Concepts practiced
- Abstract classes (`abstract class`) and abstract methods
- Multi-level inheritance (e.g. `Rombo → Cuadrado → Rectangulo → Poligono → Forma`)
- Polymorphism (`override`, using the base class as a collection type)
- Constrained generics (`GetPersonasPorTipo<T>() where T : Persona`)
- Overriding `ToString()` to display objects in a readable way

---
⬅️ [Back to Console Apps](../)
