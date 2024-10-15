// Även om det just nu endast finns ett sätt att hantera menyer
// så skapas ett interface för flexibilitetens skull. 
// Denna kan implementera vidare på valfria sätt (som exempelvis SimpleMenuManager).
public interface MenuManager {
    Menu GetCurrentMenu();
    void SetMenu(Menu menu);
}

// Eftersom det endast finns en enkel meny så skapas
// även en enkel menu manager.
public class SimpleMenuManager : MenuManager {
    // Denna variabel håller koll på vilken meny
    // som är aktiv. Just nu finns endast en meny så den är på
    // ett sätt onödig, men tanken är att man i framtiden skall
    // kunna lägga till flera menu klasser ifall man vill.
    private Menu menu;

    public SimpleMenuManager(Menu startingMenu) {
        this.menu = startingMenu;
        // Visa även upp menyn för första gången.
        this.menu.Display();
    }

    public Menu GetCurrentMenu()
    {
        return menu;
    }

    public void SetMenu(Menu menu)
    {
        // Denna metod används egentligen inte, eftersom det endast
        // finns en meny, men tanken är att man kan byta mellan
        // menyer enkelt genom att anropa metoden. Den visar även upp
        // menyn då genom '.Display()'.
        this.menu = menu;
        this.menu.Display();
    }
}