using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.MailUtils;

// DOCS: docs\providers\MailTemplateProvider.md
public interface IMailTemplateProvider
{
  string GetTemplate(string name);
  string GetCss(string name);
}

public class MailTemplateProvider : IMailTemplateProvider
{
  private readonly ILoggerAdapter<MailTemplateProvider> _logger;
  private readonly IEnvironmentAbstraction _environment;
  private readonly IPathAbstraction _path;
  private readonly IDirectoryAbstraction _directory;
  private readonly IFileAbstraction _file;
  private readonly RnMailConfig _mailConfig;
  private readonly string _templateDir;
  private readonly string _cssDir;

  public MailTemplateProvider(
    ILoggerAdapter<MailTemplateProvider> logger,
    IEnvironmentAbstraction environment,
    IPathAbstraction path,
    IDirectoryAbstraction directory,
    IFileAbstraction file,
    RnMailConfig mailConfig)
  {
    _logger = logger;
    _environment = environment;
    _path = path;
    _directory = directory;
    _file = file;
    _mailConfig = mailConfig;

    _templateDir = GenerateTemplateDirPath();
    _cssDir = GenerateCssDirPath();

    EnsureDirectoryExists(_cssDir);
  }

  public string GetTemplate(string name)
  {
    var tplFilePath = GenerateTemplatePath(name);
    if (_file.Exists(tplFilePath))
      return _file.ReadAllText(tplFilePath);

    _logger.LogError("Unable to resolve template file path: {path}", tplFilePath);
    return string.Empty;
  }

  public string GetCss(string name)
  {
    var filePath = GenerateCssPath(name);
    if (_file.Exists(filePath))
      return _file.ReadAllText(filePath);

    _logger.LogWarning("Unable to find requested CSS file: {path}", filePath);
    return string.Empty;
  }

  private string GenerateTemplateDirPath()
  {
    var templateDir = _mailConfig.TemplateDir;

    if (templateDir.StartsWith("./"))
      templateDir = _path.Join(_environment.CurrentDirectory, templateDir[2..]);

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (!_path.EndsInDirectorySeparator(templateDir))
      return _path.Join(templateDir, _path.DirectorySeparatorChar.ToString());

    return templateDir;
  }

  private string GenerateCssDirPath()
  {
    var basePath = _path.Join(_templateDir, "css");

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (!_path.EndsInDirectorySeparator(basePath))
      return _path.Join(basePath, _path.DirectorySeparatorChar.ToString());

    return basePath;
  }

  private void EnsureDirectoryExists(string path)
  {
    if(_directory.Exists(path))
      return;

    _directory.CreateDirectory(path);
  }

  private string GenerateTemplatePath(string name) =>
    _path.Join(_templateDir, $"{name}.html");

  private string GenerateCssPath(string name) =>
    _path.Join(_cssDir, $"{name}.css");
}
