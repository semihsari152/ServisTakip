function toggleAccordion(accordion) {
    accordion.classList.toggle("active");
    var content = accordion.querySelector('.accordion-content');
    content.style.display = content.style.display === 'block' ? 'none' : 'block';
}

var faultStage;

document.addEventListener("DOMContentLoaded", function () {
    $('#faultStageText').text(faultStage); // Deðeri kullanýn
});

document.addEventListener("DOMContentLoaded", function () {

    // Progress bar elementini seç
    var progressBar = document.querySelector(".progress-bar");

    // Deðerlere göre width'    i ayarla
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
            // Hata durumu için varsayýlan deðeri ayarla
            progressBar.style.width = "0%";

    }
});

document.addEventListener("DOMContentLoaded", function () {

    // Tüm adým divlerini seç
    var steps = document.querySelectorAll(".step");

    // Tüm adým divlerinin altýndaki span elemanlarýna sahip olanlarý seç
    var stepIndicators = document.querySelectorAll(".step-completed .step-indicator");

    // Tüm adým divlerini sýfýrla
    steps.forEach(function (step) {
        step.classList.remove("step-completed", "step-active");
    });

    // Deðerlere göre adýmlarý düzenle
    for (var i = 0; i <= faultStage; i++) {
        if (i < faultStage) {
            steps[i].classList.add("step-completed");

            // Sadece step-completed olan divlerin altýnda .step-indicator eklenmediyse ekle
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

    // Garanti bölümünü gizle
    var garantiDiv = document.querySelector('.garanti');
    if (faultStage !== 2) {
        garantiDiv.style.display = 'none';
    }

    // FaultStage deðeri deðiþtiðinde kontrol et ve gerekirse göster/gizle
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
            return "Teslim Alýndý";
        case 2:
            return "Ürün Ýnceleniyor";
        case 3:
            return "Arýza Tespit Edildi";
        case 4:
            return "Tamir Ediliyor";
        case 5:
            return "Ürün Hazýr";
        default:
            return "Bilinmeyen Durum";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    var faultStageText = document.getElementById('faultStageText');
    faultStageText.textContent = getStageName(faultStage);
});