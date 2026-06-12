// -----------------------------
// BED DATA (Mock backend data)
// -----------------------------
let beds = [
    { bedNumber: 1, isOccupied: false },
    { bedNumber: 2, isOccupied: true },
    { bedNumber: 3, isOccupied: false },
    { bedNumber: 4, isOccupied: true },
    { bedNumber: 5, isOccupied: false },
    { bedNumber: 6, isOccupied: false },
    { bedNumber: 7, isOccupied: true },
    { bedNumber: 8, isOccupied: false },
    { bedNumber: 9, isOccupied: true },
    { bedNumber: 10, isOccupied: false },
    { bedNumber: 11, isOccupied: true },
    { bedNumber: 12, isOccupied: false }
];


// -----------------------------
// FUNCTION: Render beds on screen
// -----------------------------
function renderBeds() {

    let container = document.getElementById("bedContainer");
    let coutntDisplay = document.getElementById("countDisplay");

    // Clear existing beds
    container.innerHTML = "";
    let occupiedCount = 0;
    // Loop through all beds
    for (let i = 0; i < beds.length; i++) {

        let bed = beds[i];

        // Create a div for each bed
        let bedDiv = document.createElement("div");
        // Assign common bed class
        bedDiv.classList.add("bed");
        coutntDisplay.innerText = "Occupied Beds: " + occupiedCount + "/" + beds.length;
       
        // Condition to decide color
        if (bed.isOccupied) {
            bedDiv.classList.add("occupied");
            occupiedCount++;
            bedDiv.innerText = "Bed " + bed.bedNumber + "\nOccupied";
        } else {
            bedDiv.classList.add("available");
            bedDiv.innerText = "Bed " + bed.bedNumber + "\nAvailable";
        }

        // Click event to toggle bed status
        if (!bed.isOccupied) {
            bedDiv.onclick = function () {
                bed.isOccupied = !bed.isOccupied;
                coutntDisplay.innerText = "Occupied Beds: " + occupiedCount + "/" + beds.length;
                renderBeds(); // Re-render UI
            }
        }
        
        // Add bed to container
        container.appendChild(bedDiv);
    }
    
    
}


// -----------------------------
// INITIAL LOAD
// -----------------------------
renderBeds();
