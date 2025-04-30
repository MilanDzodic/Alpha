document.addEventListener('DOMContentLoaded', () => {

  const modalButtons = document.querySelectorAll('[data-modal="true"]')
  modalButtons.forEach(button => {
    button.addEventListener('click', () => {
      const modalTarget = button.getAttribute('data-target')
      const modal = document.querySelector(modalTarget)

      if (modal)
        modal.style.display = 'flex';
    })
  })

  const closeButtons = document.querySelectorAll('[data-close="true"]')
  closeButtons.forEach(button => {
    button.addEventListener('click', () => {
      const modal = button.closest('.modalz')
      if (modal) {
        modal.style.display = 'none'
      }
    })
  })

  document.querySelectorAll('.image-previewer').forEach(previewer => {
    const fileInput = previewer.querySelector('input[type="file"]')
    const imagePreview = previewer.querySelector('.image-preview')

    previewer.addEventListener('click', () => fileInput.click())

    fileInput.addEventListener('change', )
  })

})

function loadImage(file)
  return new Promise((resolve, reject) => {
    const reader = new FileReader()

    reader.onerror = () => reject(new Error("Failed to load file."))
    reader.onload = (e) => {
      const img = new Image()
      img.onerror = () => reject(new Error("Failed to load image"))
      img.onload = () => resolve(img)
      img.src = e.target.result
    }

    reader.readAsDataURL(file)
})