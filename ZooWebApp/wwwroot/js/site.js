// wwwroot/js/site.js
document.addEventListener('DOMContentLoaded', function () {
    // Анимация карточек при скролле
    const cards = document.querySelectorAll('.product-card, .category-card');

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, { threshold: 0.1 });

    cards.forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(30px)';
        card.style.transition = 'all 0.6s ease';
        observer.observe(card);
    });

    // Счётчик корзины
    let cartCount = 0;
    document.querySelectorAll('.btn-sm').forEach(btn => {
        btn.addEventListener('click', function () {
            cartCount++;
            const badge = document.getElementById('cart-badge');
            if (badge) {
                badge.textContent = cartCount;
                badge.style.display = 'block';
            }
        });
    });
});