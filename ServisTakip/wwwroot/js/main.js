function toggleAccordion(accordion) {
    accordion.classList.toggle("active");
    var content = accordion.querySelector('.accordion-content');
    content.style.display = content.style.display === 'block' ? 'none' : 'block';
}

var faultStage;

document.addEventListener("DOMContentLoaded", function () {
    $('#faultStageText').text(faultStage); // De�eri kullan�n
});

document.addEventListener("DOMContentLoaded", function () {

    // Progress bar elementini se�
    var progressBar = document.querySelector(".progress-bar");

    // De�erlere g�re width'    i ayarla
    switch (faultStage) {
        case 1:
            progressBar.style.width = "16%";
            break;
        case 2:
            progressBar.style.width = "33%";
            break;
        case 3:
            progressBar.style.width = "50%";
            break;
        case 4:
            progressBar.style.width = "67%";
            break;
        case 5:
            progressBar.style.width = "84%";
            break;
        case 6:
            progressBar.style.width = "100%";
            break;
        default:
            // Hata durumu i�in varsay�lan de�eri ayarla
            progressBar.style.width = "0%";

    }
});

document.addEventListener("DOMContentLoaded", function () {

    // T�m ad�m divlerini se�
    var steps = document.querySelectorAll(".step");

    // T�m ad�m divlerinin alt�ndaki span elemanlar�na sahip olanlar� se�
    var stepIndicators = document.querySelectorAll(".step-completed .step-indicator");

    // T�m ad�m divlerini s�f�rla
    steps.forEach(function (step) {
        step.classList.remove("step-completed", "step-active");
    });

    // De�erlere g�re ad�mlar� d�zenle
    for (var i = 0; i <= faultStage; i++) {
        if (i < faultStage) {
            steps[i].classList.add("step-completed");

            // Sadece step-completed olan divlerin alt�nda .step-indicator eklenmediyse ekle
            var indicator = steps[i].querySelector(".step-indicator");
            if (!indicator) {
                indicator = document.createElement("span");
                indicator.className = "step-indicator";
                indicator.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-check"><polyline points="20 6 9 17 4 12"></polyline></svg>';
                steps[i].appendChild(indicator);
            }
        } else if (i === faultStage) {
            steps[i].classList.add("step-active");
        }
    }
});

document.addEventListener("DOMContentLoaded", function () {

    // Garanti b�l�m�n� gizle
    var garantiDiv = document.querySelector('.garanti');
    if (faultStage !== 2) {
        garantiDiv.style.display = 'none';
    }

    // FaultStage de�eri de�i�ti�inde kontrol et ve gerekirse g�ster/gizle
    document.getElementById('garantiBelgesi').addEventListener('change', function () {
        if (faultStage === 2) {
            garantiDiv.style.display = 'block';
        } else {
            garantiDiv.style.display = 'none';
        }
    });
});

function getStageName(stage) {
    switch (stage) {
        case 1:
            return "Teslim Al�nd�";
        case 2:
            return "�r�n �nceleniyor";
        case 3:
            return "Ar�za Tespit Edildi";
        case 4:
            return "Tamir Ediliyor";
        case 5:
            return "�r�n Haz�r";
        default:
            return "Bilinmeyen Durum";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var faultStageText = document.getElementById('faultStageText');
    faultStageText.textContent = getStageName(faultStage);
});