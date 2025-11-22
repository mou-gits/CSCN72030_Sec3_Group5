# PowerShell script to create and activate a virtual environment and install requirements
param(
    [string]$VenvName = ".venv"
)

python -m venv $VenvName
Write-Host "Virtual environment '$VenvName' created."

Write-Host "To activate in PowerShell run: .\$VenvName\Scripts\Activate.ps1"
Write-Host "Installing pip and requirements..."
& "$VenvName\Scripts\python.exe" -m pip install --upgrade pip
& "$VenvName\Scripts\python.exe" -m pip install -r requirements.txt
Write-Host "Done. Activate the venv before running the app."
