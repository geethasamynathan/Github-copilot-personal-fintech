# Ghost Text Suggestions in GitHub Copilot

## What is Ghost Text Suggestions?

**Ghost Text Suggestions** in GitHub Copilot are the **light gray code suggestions** that appear automatically while you are typing code in your editor.

GitHub calls these **ghost text suggestions** because the suggested code looks like “shadow text” or “preview text.” It is **not added to your file yet** until you accept it.

GitHub Copilot provides these coding suggestions as you type. You can also write a natural-language comment, and Copilot can suggest code based on that comment.

---

## Simple Example

Suppose you type this in JavaScript:

```javascript
function addNumbers(a, b) {
```

Copilot may show this in gray color:

```javascript
    return a + b;
}
```

That gray suggestion is called **ghost text**.

---

## How to Use Ghost Text Suggestions

| Action | Shortcut |
|---|---|
| Accept suggestion | `Tab` |
| Reject suggestion | `Esc` |
| See next suggestion | `Alt + ]` |
| See previous suggestion | `Alt + [` |
| Accept word-by-word / part of suggestion | `Ctrl + →` |

In VS Code, Copilot shows these suggestions at your current cursor position as dimmed inline text.

---

## Real-World Use Case

Imagine you are writing a login validation function:

```javascript
function validateLogin(username, password) {
```

Copilot may suggest:

```javascript
    if (!username || !password) {
        return false;
    }
    return true;
}
```

You can press **Tab** to accept it, or ignore it and write your own logic.

---

## Trainer Explanation

You can explain it to freshers like this:

> Ghost Text is like a smart assistant sitting inside the code editor. While the developer types, Copilot predicts the next line or block of code and shows it in gray color. The code is only a suggestion. The developer must review it and press Tab to accept it.

---

## Where Ghost Text Suggestions Are Useful

Ghost Text is useful for:

1. Completing repeated code quickly.
2. Writing boilerplate code.
3. Suggesting function bodies.
4. Creating loops, conditions, and validations.
5. Converting comments into code.

---

## Important Caution

Developers should **not blindly accept** every suggestion.

Copilot-generated code should be checked for:

1. Correctness.
2. Security.
3. Performance.
4. Project coding standards.
5. Business logic accuracy.

GitHub Copilot suggestions are visually shown as ghost text so developers can clearly understand that the generated code is only a suggestion, not final approved code.

---

## Simple Summary

**Ghost Text Suggestions** means:

> GitHub Copilot predicts and shows code in gray color while you type. You can press `Tab` to accept it or `Esc` to reject it.

